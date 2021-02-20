using CSVJSONLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVJSON_Test.Dummy_Classes
{
	public class Dummy_UniqueNameProvider : IUniqueNameProvider
	{
		public string GetUniqueName(string[] names, string preferredName)
		{
			return Guid.NewGuid().ToString();
		}

		public string GetUniqueName(string[] names)
		{
			return Guid.NewGuid().ToString();
		}
	}
}
