using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_to_JSON
{
	class Program
	{
		static void Main(string[] args)
		{
			IContainer container = Containerization.BuildContainer(args);
			container.Resolve<IApplication>();
		}
	}
}
