using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SalesMind.Infrastructure.Migrations.Tenant
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dev");

            migrationBuilder.CreateTable(
                name: "customers",
                schema: "dev",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<string>(type: "text", nullable: false),
                    modified_by = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "inventories",
                schema: "dev",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    WarehouseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                schema: "dev",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    street = table.Column<string>(type: "text", nullable: true),
                    city = table.Column<string>(type: "text", nullable: true),
                    state = table.Column<string>(type: "text", nullable: true),
                    country = table.Column<string>(type: "text", nullable: true),
                    zip_code = table.Column<string>(type: "text", nullable: true),
                    order_no = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                schema: "dev",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "stores",
                schema: "dev",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                schema: "dev",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<string>(type: "text", nullable: false),
                    modified_by = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "warehouses",
                schema: "dev",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    location = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "inventory_logs",
                schema: "dev",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    note = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    change_type = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    InventoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory_logs", x => x.id);
                    table.ForeignKey(
                        name: "FK_inventory_logs_inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalSchema: "dev",
                        principalTable: "inventories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_items",
                schema: "dev",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_id = table.Column<int>(type: "integer", nullable: false),
                    product_sku_id = table.Column<long>(type: "bigint", nullable: false),
                    order_no = table.Column<string>(type: "text", nullable: false),
                    sku_attributes = table.Column<string>(type: "jsonb", nullable: true),
                    product_file_id = table.Column<Guid>(type: "uuid", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Units = table.Column<int>(type: "integer", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_order_items_orders_order_id",
                        column: x => x.order_id,
                        principalSchema: "dev",
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_skus",
                schema: "dev",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: true),
                    cost = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    stock_quantity = table.Column<int>(type: "integer", nullable: false),
                    product_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_skus", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_skus_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "dev",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPicture",
                schema: "dev",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Format = table.Column<string>(type: "text", nullable: true),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    product_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPicture_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "dev",
                        principalTable: "products",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "product_sku_attributes",
                schema: "dev",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    value = table.Column<string>(type: "text", nullable: true),
                    product_sku_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_sku_attributes", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_sku_attributes_product_skus_product_sku_id",
                        column: x => x.product_sku_id,
                        principalSchema: "dev",
                        principalTable: "product_skus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_inventory_logs_InventoryId",
                schema: "dev",
                table: "inventory_logs",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_order_id",
                schema: "dev",
                table: "order_items",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_sku_attributes_product_sku_id",
                schema: "dev",
                table: "product_sku_attributes",
                column: "product_sku_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_skus_product_id",
                schema: "dev",
                table: "product_skus",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPicture_product_id",
                schema: "dev",
                table: "ProductPicture",
                column: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customers",
                schema: "dev");

            migrationBuilder.DropTable(
                name: "inventory_logs",
                schema: "dev");

            migrationBuilder.DropTable(
                name: "order_items",
                schema: "dev");

            migrationBuilder.DropTable(
                name: "product_sku_attributes",
                schema: "dev");

            migrationBuilder.DropTable(
                name: "ProductPicture",
                schema: "dev");

            migrationBuilder.DropTable(
                name: "stores",
                schema: "dev");

            migrationBuilder.DropTable(
                name: "suppliers",
                schema: "dev");

            migrationBuilder.DropTable(
                name: "warehouses",
                schema: "dev");

            migrationBuilder.DropTable(
                name: "inventories",
                schema: "dev");

            migrationBuilder.DropTable(
                name: "orders",
                schema: "dev");

            migrationBuilder.DropTable(
                name: "product_skus",
                schema: "dev");

            migrationBuilder.DropTable(
                name: "products",
                schema: "dev");
        }
    }
}
