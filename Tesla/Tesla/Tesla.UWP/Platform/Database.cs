using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaDefinition;
using TeslaDatabase.Interfaces.Platform;

namespace Tesla.UWP.Platform
{
	public class Database : IPlatformDatabase
	{
		private string _path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, InfrastructureRules.MainDatabase);
		private SQLiteConnectionWithLock _conn = null;
		private object _lock = new object();

		public SQLiteConnectionWithLock Connection
		{
			get
			{
				lock (_lock)
					return _conn ?? (_conn = new SQLiteConnectionWithLock(new
					   SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), new SQLiteConnectionString(_path, false)));
			}
		}

	}
}
