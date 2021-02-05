using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace CSV_to_JSON
{
	public static class Containerization
	{
		public static IContainer BuildContainer(string[] args)
		{
			var builder = new ContainerBuilder();

			ISwitchArgs switchArgs = new SwitchArgs(args);

			builder.RegisterType<Application>().As<IApplication>();

			return builder.Build();
		}
	}
}
