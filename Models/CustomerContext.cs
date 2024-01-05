using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerCRUD.Models
{
    public partial class CustomerContext : DbContext
    {
        //public CustomerContext()
        //{
        //}

        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomersDatum> CustomersData { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                   // optionsBuilder.UseSqlServer(DbContextOptionsBuilder. );
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Customer;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomersDatum>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.Property(e => e.FirstName)
                    //.HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    //.HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    //.HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.CreatedDate)                    
                    .IsFixedLength();

                entity.Property(e => e.LastUpdatedDate)                    
                    .IsFixedLength();                
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
