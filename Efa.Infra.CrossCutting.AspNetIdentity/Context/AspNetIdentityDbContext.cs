using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Efa.Infra.CrossCutting.AspNetIdentity.Infra;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Efa.Infra.CrossCutting.AspNetIdentity.Context
{
    public class AspNetIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public AspNetIdentityDbContext() : base("EfaConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static AspNetIdentityDbContext Create()
        {
            return new AspNetIdentityDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //General custom properties
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            base.OnModelCreating(modelBuilder);
        }
    }
}
