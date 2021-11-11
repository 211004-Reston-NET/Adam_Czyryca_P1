﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TTGDL;

namespace TTGDL.Migrations
{
    [DbContext(typeof(database1Context))]
    partial class database1ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TTGModel.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("EmailPhone")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("TTGModel.ItemsInOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LineItemId")
                        .HasColumnType("int")
                        .HasColumnName("LineItem_ID");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("Order_ID");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LineItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("ItemsInOrder");
                });

            modelBuilder.Entity("TTGModel.LineItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("Product")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Store")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("Product");

                    b.HasIndex("Store");

                    b.ToTable("LineItem");
                });

            modelBuilder.Entity("TTGModel.Manager", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("employee_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("EmailPhone")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Store")
                        .HasColumnType("int")
                        .HasColumnName("store");

                    b.HasKey("EmployeeId")
                        .HasName("PKey_Manager");

                    b.HasIndex("Store");

                    b.ToTable("Manager");
                });

            modelBuilder.Entity("TTGModel.Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Customer")
                        .HasColumnType("int");

                    b.Property<int>("StoreFront")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Customer");

                    b.HasIndex("StoreFront");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TTGModel.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Catagory")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("catagory");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("TTGModel.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Name")
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("TTGModel.ItemsInOrder", b =>
                {
                    b.HasOne("TTGModel.LineItem", "LineItem")
                        .WithMany("ItemsInOrder")
                        .HasForeignKey("LineItemId")
                        .HasConstraintName("FKey_ToLineItem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TTGModel.Orders", "Order")
                        .WithMany("ItemsInOrder")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FKey_ToOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LineItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("TTGModel.LineItem", b =>
                {
                    b.HasOne("TTGModel.Customer", null)
                        .WithMany("OrderList")
                        .HasForeignKey("CustomerId");

                    b.HasOne("TTGModel.Product", "ProductNavigation")
                        .WithMany("LineItems")
                        .HasForeignKey("Product")
                        .HasConstraintName("FKey_ToProduct")
                        .IsRequired();

                    b.HasOne("TTGModel.Store", "StoreNavigation")
                        .WithMany("LineItems")
                        .HasForeignKey("Store")
                        .HasConstraintName("FKey_ToStore_")
                        .IsRequired();

                    b.Navigation("ProductNavigation");

                    b.Navigation("StoreNavigation");
                });

            modelBuilder.Entity("TTGModel.Manager", b =>
                {
                    b.HasOne("TTGModel.Store", "StoreNavigation")
                        .WithMany("Managers")
                        .HasForeignKey("Store")
                        .HasConstraintName("FKey_ToStoreManaging")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StoreNavigation");
                });

            modelBuilder.Entity("TTGModel.Orders", b =>
                {
                    b.HasOne("TTGModel.Customer", "CustomerNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("Customer")
                        .HasConstraintName("FKey_ToCustomer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TTGModel.Store", "StoreNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("StoreFront")
                        .HasConstraintName("FKey_ToStore")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerNavigation");

                    b.Navigation("StoreNavigation");
                });

            modelBuilder.Entity("TTGModel.Customer", b =>
                {
                    b.Navigation("OrderList");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("TTGModel.LineItem", b =>
                {
                    b.Navigation("ItemsInOrder");
                });

            modelBuilder.Entity("TTGModel.Orders", b =>
                {
                    b.Navigation("ItemsInOrder");
                });

            modelBuilder.Entity("TTGModel.Product", b =>
                {
                    b.Navigation("LineItems");
                });

            modelBuilder.Entity("TTGModel.Store", b =>
                {
                    b.Navigation("LineItems");

                    b.Navigation("Managers");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
