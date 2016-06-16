using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TeslaDatabase.Interfaces.Platform;
using SQLite.Net;
using System.IO;
using TeslaDefinition;

namespace Tesla.Droid.Platform
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
                       SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid(), new SQLiteConnectionString(_path, false)));
            }
        }
    }
}