using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using CSV_to_JSON.Init_Classes;
using CSVJSONLib;

namespace CSV_to_JSON
{
	public static class Containerization
	{
		public static IContainer BuildContainer(string[] args)
		{
			var builder = new ContainerBuilder();

			ISwitchArgs switchArgs = new SwitchArgs(args);
			builder.RegisterInstance(switchArgs).As<ISwitchArgs>();
			builder.RegisterType<Application>().As<IApplication>();
			builder.RegisterType<OutputHandler>().As<IOutputHandler>();

			builder.RegisterType<CSVReportReader>().As<ICSVReportReader>();
			builder.RegisterType<CSVTable>().As<ICSVTable>();
			builder.RegisterType<ReportContainer>().As<IReportContainer>();
			builder.RegisterType<UniqueNameProvider>().As<IUniqueNameProvider>();

			return builder.Build();
		}
	}
}
