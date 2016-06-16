using SQLite.Net;
using System;
using System.IO;
using TeslaDatabase.Interfaces.Platform;
using TeslaDefinition;

namespace Tesla.iOS.Platform
{
    public class Database : IPlatformDatabase
    {
        private string _path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), InfrastructureRules.MainDatabase);
        private SQLiteConnectionWithLock _conn = null;
        private object _lock = new object();

        public SQLiteConnectionWithLock Connection
        {
            get
            {
                lock (_lock)
                    return _conn ?? (_conn = new SQLiteConnectionWithLock(new
                       SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS(), new SQLiteConnectionString(_path, false)));
            }     
        }
    }
}
