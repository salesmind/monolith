﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SalesMind.Infrastructure;

#nullable disable

namespace SalesMind.Infrastructure.Migrations.Tenant
{
    [DbContext(typeof(TenantDbContext))]
    partial class TenantDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dev")
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SalesMind.Domain.Aggregates.OrderAggregate.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_at");

                    b.Property<string>("OrderNo")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("order_no");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.ToTable("orders", "dev");
                });

            modelBuilder.Entity("SalesMind.Domain.Aggregates.OrderAggregate.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<decimal>("Discount")
                        .HasColumnType("numeric");

                    b.Property<Guid?>("ProductFileId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_file_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer")
                        .HasColumnName("product_id");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("order_no");

                    b.Property<long>("ProductSkuId")
                        .HasColumnType("bigint")
                        .HasColumnName("product_sku_id");

                    b.Property<string>("SkuAttributes")
                        .HasColumnType("jsonb")
                        .HasColumnName("sku_attributes");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric");

                    b.Property<int>("Units")
                        .HasColumnType("integer");

                    b.Property<Guid>("order_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("order_id");

                    b.ToTable("order_items", "dev");
                });

            modelBuilder.Entity("SalesMind.Domain.Aggregates.ProductAggregate.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.ToTable("products", "dev");
                });

            modelBuilder.Entity("SalesMind.Domain.Aggregates.ProductAggregate.ProductPicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("integer");

                    b.Property<Guid>("FileId")
                        .HasColumnType("uuid");

                    b.Property<string>("Format")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("product_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("product_id");

                    b.ToTable("ProductPicture", "dev");
                });

            modelBuilder.Entity("SalesMind.Domain.Aggregates.ProductAggregate.ProductSku", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<decimal>("Cost")
                        .HasColumnType("DECIMAL(18,2)")
                        .HasColumnName("cost");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(18,2)")
                        .HasColumnName("price");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("integer")
                        .HasColumnName("stock_quantity");

                    b.Property<int>("product_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("product_id");

                    b.ToTable("product_skus", "dev");
                });

            modelBuilder.Entity("SalesMind.Domain.Aggregates.ProductAggregate.ProductSkuAttribute", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.Property<long>("product_sku_id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("product_sku_id");

                    b.ToTable("product_sku_attributes", "dev");
                });

            modelBuilder.Entity("SalesMind.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_at");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text")
                        .HasColumnName("modified_by");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("customers", "dev");
                });

            modelBuilder.Entity("SalesMind.Domain.Entities.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("inventories", "dev");
                });

            modelBuilder.Entity("SalesMind.Domain.Entities.InventoryLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("ChangeType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("change_type");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int>("InventoryId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_at");

                    b.Property<string>("Note")
                        .HasColumnType("text")
                        .HasColumnName("note");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("InventoryId");

                    b.ToTable("inventory_logs", "dev");
                });

            modelBuilder.Entity("SalesMind.Domain.Entities.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.ToTable("stores", "dev");
                });

            modelBuilder.Entity("SalesMind.Domain.Entities.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_at");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text")
                        .HasColumnName("modified_by");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("suppliers", "dev");
                });

            modelBuilder.Entity("SalesMind.Domain.Entities.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Location")
                        .HasColumnType("text")
                        .HasColumnName("location");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("warehouses", "dev");
                });

            modelBuilder.Entity("SalesMind.Domain.Aggregates.OrderAggregate.Order", b =>
                {
                    b.OwnsOne("SalesMind.Domain.Aggregates.OrderAggregate.OrderAddress", "Address", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uuid");

                            b1.Property<string>("City")
                                .HasColumnType("text")
                                .HasColumnName("city");

                            b1.Property<string>("Country")
                                .HasColumnType("text")
                                .HasColumnName("country");

                            b1.Property<string>("State")
                                .HasColumnType("text")
                                .HasColumnName("state");

                            b1.Property<string>("Street")
                                .HasColumnType("text")
                                .HasColumnName("street");

                            b1.Property<string>("ZipCode")
                                .HasColumnType("text")
                                .HasColumnName("zip_code");

                            b1.HasKey("OrderId");

                            b1.ToTable("orders", "dev");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("SalesMind.Domain.Aggregates.OrderAggregate.OrderItem", b =>
                {
                    b.HasOne("SalesMind.Domain.Aggregates.OrderAggregate.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("order_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SalesMind.Domain.Aggregates.ProductAggregate.ProductPicture", b =>
                {
                    b.HasOne("SalesMind.Domain.Aggregates.ProductAggregate.Product", null)
                        .WithMany("ProductPictures")
                        .HasForeignKey("product_id");
                });

            modelBuilder.Entity("SalesMind.Domain.Aggregates.ProductAggregate.ProductSku", b =>
                {
                    b.HasOne("SalesMind.Domain.Aggregates.ProductAggregate.Product", null)
                        .WithMany("ProductSkus")
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SalesMind.Domain.Aggregates.ProductAggregate.ProductSkuAttribute", b =>
                {
                    b.HasOne("SalesMind.Domain.Aggregates.ProductAggregate.ProductSku", null)
                        .WithMany("ProductSkuAttributes")
                        .HasForeignKey("product_sku_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SalesMind.Domain.Entities.InventoryLog", b =>
                {
                    b.HasOne("SalesMind.Domain.Entities.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("SalesMind.Domain.Aggregates.OrderAggregate.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("SalesMind.Domain.Aggregates.ProductAggregate.Product", b =>
                {
                    b.Navigation("ProductPictures");

                    b.Navigation("ProductSkus");
                });

            modelBuilder.Entity("SalesMind.Domain.Aggregates.ProductAggregate.ProductSku", b =>
                {
                    b.Navigation("ProductSkuAttributes");
                });
#pragma warning restore 612, 618
        }
    }
}