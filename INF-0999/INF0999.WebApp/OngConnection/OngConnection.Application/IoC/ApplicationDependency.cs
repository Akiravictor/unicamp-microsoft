using Microsoft.Extensions.DependencyInjection;
using OngConnection.Application.Interfaces;
using OngConnection.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngConnection.Application.IoC
{
	public static class ApplicationDependency
	{
		public static void RegisterApplicationServices(this IServiceCollection services)
		{
			services.AddScoped<IUserServices, UserServices>();
			services.AddScoped<IFormServices, FormServices>();
			services.AddScoped<IDashboardServices, DashboardServices>();
		}
	}
}
