using Exrin.Common;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TeslaDatabase.Enum;
using TeslaDatabase.Interfaces.Platform;
using TeslaDatabase.Model;
using TeslaDefinition.Interfaces.Database;
using System.Reflection;
using System.Collections;

namespace TeslaDatabase
{
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
