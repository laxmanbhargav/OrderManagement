// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderManagement.Data.Contexts;

#nullable disable

namespace OrderManagement.Data.Migrations
{
    [DbContext(typeof(OrderManagementContext))]
    [Migration("20220616044748_SeedIntialData")]
    partial class SeedIntialData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OrderManagement.Core.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("(newsequentialid())");

                    b.Property<string>("Description")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("userId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Order", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("bd673eb8-104f-4079-b0f3-b2c1d430b808"),
                            Description = "This is my first order",
                            Name = "Order 1",
                            UserId = new Guid("01d89928-5385-4c4f-bbde-889b6afce928")
                        },
                        new
                        {
                            Id = new Guid("97d98542-1342-4f47-9921-a305bb5b65c0"),
                            Description = "This is my Second Order",
                            Name = "Order 2",
                            UserId = new Guid("8a153499-0dba-4e7f-af83-a2f08e284f8d")
                        });
                });

            modelBuilder.Entity("OrderManagement.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("(newsequentialid())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("password");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("01d89928-5385-4c4f-bbde-889b6afce928"),
                            Email = "johndoe@abccorp.com",
                            Name = "John Doe",
                            Password = "12345678"
                        },
                        new
                        {
                            Id = new Guid("8a153499-0dba-4e7f-af83-a2f08e284f8d"),
                            Email = "jimcarey@abccorp.com",
                            Name = "Jim Carey",
                            Password = "12345678"
                        });
                });

            modelBuilder.Entity("OrderManagement.Core.Entities.Order", b =>
                {
                    b.HasOne("OrderManagement.Core.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_User_Order");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OrderManagement.Core.Entities.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
