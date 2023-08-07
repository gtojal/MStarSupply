using Microsoft.EntityFrameworkCore;
using MStarSupplyApp.Data.Configurations;
using MStarSupplyApp.Data.Entities;

namespace MStarSupplyApp.Data.Contexts
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MStarSupplyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MercadoriaConfiguration());
            modelBuilder.ApplyConfiguration(new MovimentacaoConfiguration());
        }

        public DbSet<Mercadoria> Mercadoria { get; set; }
        public DbSet<Movimentacao> Movimentacao { get; set; }
    }
}
