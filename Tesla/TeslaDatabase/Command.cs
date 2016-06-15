using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TeslaDatabase.Enum;

namespace TeslaDatabase
{
	internal class Command
	{

		public Type TableType { get; set; }

		public object Item { get; set; }

		public ExecuteType Execute { get; set; }

		public int Result { get; set; } = -1;

		public IList<object> ResultList { get; set; }

		private ManualResetEvent ExecutedLock { get; set; } = new ManualResetEvent(false);

		public void Wait()
		{
			ExecutedLock.WaitOne();
		}

		public void Release()
		{
			ExecutedLock.Set();
		}
		
	}
}
