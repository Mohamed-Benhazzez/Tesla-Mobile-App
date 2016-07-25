// The MIT License(MIT)
// Copyright(c) 2016 Adam Pedley
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
// to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

namespace TeslaDatabase
{

    using Exrin.Common;
    using SQLite.Net;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using Enum;
    using Interfaces.Platform;
    using Model;
    using TeslaDefinition.Interfaces.Database;

    public class Database : IDatabase
	{
		IPlatformDatabase _database = null;
		private BlockingQueue<Command> _queueCommand = null;
		private CancellationTokenSource _tokenSource = null;

		public Database(IPlatformDatabase database)
		{
			_database = database;
			_queueCommand = new BlockingQueue<Command>();

            // Background Init of database.
            Init();
           
            Start();
            
		}

		public Task Init()
		{
            // TODO: Shouldn't be as bad as this
			Task.Run(CreateTable<ServiceCentre>);
			Task.Run(CreateTable<Booking>);

            return Task.FromResult(true);
		}

		public void Start()
		{
			var state = new object();

			_tokenSource = new CancellationTokenSource();

			Task.Run(() =>
			{

				var connection = _database.Connection;

				do  //TODO: Should get multiple back from Dequeue so I can bulk transact as needed, also look at a single get / get with parameters
				{
					bool transactionStarted = false;
					try
					{						
						var data = _queueCommand.Dequeue();
						var result = 0;

						connection.BeginTransaction();
						transactionStarted = true;

						switch (data.Execute)
						{
							case ExecuteType.CreateTable:
								result = connection.CreateTable(data.TableType);
								break;
							case ExecuteType.Delete:
								result = connection.Delete(data.Item);
								break;
							case ExecuteType.Insert:
								result = connection.Insert(data.Item);
								break;
							case ExecuteType.Update:
								result = connection.Update(data.Item);
								break;
							case ExecuteType.Get:
								var method =
										typeof(SQLiteConnectionWithLock)
										.GetRuntimeMethod("Query", new Type[] { typeof(string), typeof(object[]) })
										.MakeGenericMethod(new Type[] { data.TableType })
										.Invoke(connection, new object[] { $"SELECT * FROM {data.TableType.Name}", new object[] { } });

								data.ResultList = ((IList)method).Cast<object>().ToList();
								break;
						}

						connection.Commit();

						data.Result = result;

						data.Release();

						transactionStarted = false;

					}
					catch (Exception ex)
					{						
						Debug.WriteLine(ex.Message);
					}
					finally
					{
						if (transactionStarted)
						{
							connection.Rollback();

							transactionStarted = false;
						}
					}

				} while (true);

			}, _tokenSource.Token);

		}

		public Task<int> Delete<T>(T item)
		{
			var cmd = new Command() { TableType = typeof(T), Item = item, Execute = ExecuteType.Insert };
			
			_queueCommand.Enqueue(cmd);

			cmd.Wait();

			return Task.FromResult(cmd.Result);
		}
		
		private Task CreateTable<T>()
		{
			var cmd = new Command() { TableType = typeof(T), Execute = ExecuteType.CreateTable };

			_queueCommand.Enqueue(cmd);

			cmd.Wait();

			return Task.FromResult(cmd.Result);
		}

		public Task<int> Insert<T>(T item)
		{
			var cmd = new Command() { TableType = typeof(T), Item = item, Execute = ExecuteType.Insert };

			_queueCommand.Enqueue(cmd);

			cmd.Wait();

			return Task.FromResult(cmd.Result);
		}

		public Task<int> Update<T>(T item)
		{
			var cmd = new Command() { TableType = typeof(T), Item = item, Execute = ExecuteType.Update };

			_queueCommand.Enqueue(cmd);

			cmd.Wait();

			return Task.FromResult(cmd.Result);
		}

		public Task<IList<T>> GetAll<T>()
		{
			var cmd = new Command() { TableType = typeof(T), Execute = ExecuteType.Get };

			_queueCommand.Enqueue(cmd);

			cmd.Wait();

			IList<T> list = cmd.ResultList.Cast<T>().ToList();

			return Task.FromResult(list);
		}
	}
}
