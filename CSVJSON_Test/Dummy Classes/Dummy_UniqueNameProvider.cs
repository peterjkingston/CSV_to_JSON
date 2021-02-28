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
            if (names.Contains(preferredName))
            {
				return Guid.NewGuid().ToString();
			}
            else
            {
				return preferredName;
            }
			
		}

		public string GetUniqueName(string[] names)
		{
			return Guid.NewGuid().ToString();
		}
	}
}
