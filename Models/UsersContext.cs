using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RegistrationLogin.Models
{
    public partial class UsersContext : DbContext
    {
        public UsersContext()
        {
        }

        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LoginUser> LoginUsers { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductModel> ProductModels { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-S4ROCGFN\\SQLEXPRESS01;Database=Users;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginUser>(entity =>
            {
                entity.ToTable("LoginUser");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Surname).HasMaxLength(30);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductEnteredDate).HasColumnType("datetime");

                entity.Property(e => e.ProductName).HasMaxLength(200);

                entity.HasOne(d => d.ProductModel)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductModelId)
                    .HasConstraintName("FK__Products__Produc__5EBF139D");
            });

            modelBuilder.Entity<ProductModel>(entity =>
            {
                entity.Property(e => e.ProductModelName).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
