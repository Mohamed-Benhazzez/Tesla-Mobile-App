using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaDefinition.Interfaces.Database
{
	public interface IDatabase
	{

		Task Init();

		Task<int> Insert<T>(T item);

		Task<int> Update<T>(T item);

		Task<int> Delete<T>(T item);

		Task<IList<T>> GetAll<T>();

	}
}
