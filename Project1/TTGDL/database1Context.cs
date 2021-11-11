using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TTGModel;

#nullable disable

namespace TTGDL
{
    public partial class database1Context : DbContext
    {
        public database1Context()
        {
        }

        public database1Context(DbContextOptions<database1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<ItemsInOrder> ItemsInOrders { get; set; }
        public virtual DbSet<LineItem> LineItems { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.EmailPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ItemsInOrder>(entity =>
            {
                entity.ToTable("ItemsInOrder");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LineItemId).HasColumnName("LineItem_ID");

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.HasOne(d => d.LineItem)
                    .WithMany(p => p.ItemsInOrder)
                    .HasForeignKey(d => d.LineItemId)
                    .HasConstraintName("FKey_ToLineItem");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ItemsInOrder)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FKey_ToOrder");
            });

            modelBuilder.Entity<LineItem>(entity =>
            {
                entity.ToTable("LineItem");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.Product)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKey_ToProduct");

                entity.HasOne(d => d.StoreNavigation)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.Store)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKey_ToStore_");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PKey_Manager");

                entity.ToTable("Manager");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.EmailPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Store).HasColumnName("store");

                entity.HasOne(d => d.StoreNavigation)
                    .WithMany(p => p.Managers)
                    .HasForeignKey(d => d.Store)
                    .HasConstraintName("FKey_ToStoreManaging");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Customer)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKey_ToCustomer");

                entity.HasOne(d => d.StoreNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreFront)
                    .HasConstraintName("FKey_ToStore");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Catagory)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("catagory");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
