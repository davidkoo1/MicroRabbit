﻿using MicroRabbit.Transfer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroRabbit.Transfer.Data.Context
{
    public class TransferDbContext : DbContext
    {
        public TransferDbContext(DbContextOptions<TransferDbContext> options) : base(options)
        {
        }
        public DbSet<TransferLog> TransferLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<TransferLog>(entity =>
            //{
            //    entity.Property(e => e.TransferAmount)
            //          .HasColumnType("decimal(18,2)");
            //});
        }
    }
}
