using Microsoft.Extensions.DependencyInjection;
using OngConnection.Domain.Interfaces;
using OngConnection.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngConnection.Domain.IoC
{
	public static class DomainDependency
	{
		public static void RegisterDomainServices(this IServiceCollection services)
		{
			services.AddScoped<IOngServices, OngServices>();
			services.AddScoped<ISocialWorkerServices, SocialWorkerServices>();
			services.AddScoped<IFamilyServices, FamilyServices>();
		}
	}
}
