using Microsoft.Extensions.DependencyInjection;
using OngConnection.Domain.Repositories;
using OngConnection.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngConnection.Infrastructure.IoC
{
	public static class DatabaseDependency
	{
		public static void RegisterDatabaseServices(this IServiceCollection services)
		{
			services.AddScoped<IFamilyRepository, FamilyRepository>();
			services.AddScoped<IOngRepository, OngRepository>();
			services.AddScoped<ISocialWorkerRepository, SocialWorkerRepository>();
		}
	}
}
