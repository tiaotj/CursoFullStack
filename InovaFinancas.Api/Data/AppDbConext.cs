using InovaFinancas.Api.Models;
using InovaFinancas.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Principal;

namespace InovaFinancas.Api.Data
{
	public class AppDbConext:IdentityDbContext
		<User,
		IdentityRole<long>, 
		long,
		IdentityUserClaim<long>,
		IdentityUserRole<long>,
		IdentityUserLogin<long>,
		IdentityRoleClaim<long>,
		IdentityUserToken<long>>
	{
        public AppDbConext(DbContextOptions<AppDbConext> options):base(options)
        {
				
        }
        public DbSet<Categoria> Categorias { get; set; } = null!;
        public DbSet<Transacao> Transacoes { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
