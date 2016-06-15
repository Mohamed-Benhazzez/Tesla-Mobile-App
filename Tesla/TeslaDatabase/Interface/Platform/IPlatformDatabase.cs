using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaDatabase.Interfaces.Platform
{
	public interface IPlatformDatabase
	{
		SQLiteConnectionWithLock Connection { get; }
	}
}
