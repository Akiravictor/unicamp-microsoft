using JewelCollector.Application.IoC;
using JewelCollector.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JewelCollector.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args);
            builder.ConfigureServices(services => 
            {
                services.AddHostedService<Worker>();
                services.AddApplicationDependencies();
            });

            var host = builder.Build();

            host.Run();
        }
    }
}