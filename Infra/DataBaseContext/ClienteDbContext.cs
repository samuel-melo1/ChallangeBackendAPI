using BackendChallengeApi.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace BackendChallengeApi.Infra.Repositories
{
    public class ClienteDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=root;Host=localhost;Port=5432;Database=cliente"); 
            base.OnConfiguring(optionsBuilder);
        }
    }
}
