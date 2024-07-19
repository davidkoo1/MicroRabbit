using MicroRabbit.Banking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroRabbit.Banking.Infrastructure.Persistance
{
    public class BankingDbContext : DbContext
    {

        public BankingDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AccountBalance)
                      .HasColumnType("decimal(18,2)");
            });
        }

    }
}
