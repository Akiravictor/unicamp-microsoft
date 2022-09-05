using JewelCollector.Application.Interfaces;
using JewelCollector.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Application.IoC
{
    public static class ApplicationDependencies
    {
        public static void AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<IMapServices, MapServices>();
            services.AddScoped<IRobotServices, RobotServices>();
        }
    }
}
