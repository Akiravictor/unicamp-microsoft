using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OngConnection.Domain.Models;

namespace OngConnection.Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Ong>? DbOng { get; set; }

		public DbSet<Family>? DbFamily { get; set; }

		public DbSet<SocialWorker>? DbSocialWorker { get; set; }

	}
}