using Autofac;

namespace DesignPatterns.Decorator
{
    public class DecoratorDI
    {
        public interface IReportingService
        {
            void Report();
        }

        public class ReportingService : IReportingService
        {
            public void Report()
            {
                Console.WriteLine("the report");
            }
        }

        public class ReportingServiceWithLogging : IReportingService
        {
            private IReportingService _reportingService;

            public ReportingServiceWithLogging(IReportingService reportingService)
            {
                _reportingService = reportingService;
            }

            public void Report()
            {
                Console.WriteLine("log");
            }
        }

        public static void Print()
        {
            var build = new ContainerBuilder();
            build.RegisterType<ReportingService>().Named<IReportingService>("reporting");
            build.RegisterDecorator<IReportingService>
                ((context, service) => new ReportingServiceWithLogging(service), "reporting");

            using (var container = build.Build())
            {
                var report = container.Resolve<IReportingService>();
                report.Report();
            }
        }
    }
}
