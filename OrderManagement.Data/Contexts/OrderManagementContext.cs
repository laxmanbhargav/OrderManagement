using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OrderManagement.Core.Entities;


namespace OrderManagement.Data.Contexts
{
    public partial class OrderManagementContext : DbContext
    {
        public OrderManagementContext()
        {
        }

        public OrderManagementContext(DbContextOptions<OrderManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=OrderManagement;Data Source=LAPTOP-A742MMVM");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Order");
                entity.HasData(new Order { Id = Guid.Parse("bd673eb8-104f-4079-b0f3-b2c1d430b808"), Name = "Order 1", Description = "This is my first order", UserId = Guid.Parse("01d89928-5385-4c4f-bbde-889b6afce928") }, new Order { Id = Guid.Parse("97d98542-1342-4f47-9921-a305bb5b65c0"), Name = "Order 2", Description = "This is my Second Order", UserId = Guid.Parse("8a153499-0dba-4e7f-af83-a2f08e284f8d") });
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("password");
                entity.HasData(new User { Id = Guid.Parse("01d89928-5385-4c4f-bbde-889b6afce928"), Email = "johndoe@abccorp.com", Password = "12345678", Name = "John Doe" }, new User { Id = Guid.Parse("8a153499-0dba-4e7f-af83-a2f08e284f8d"), Name = "Jim Carey", Email = "jimcarey@abccorp.com", Password = "12345678" });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
