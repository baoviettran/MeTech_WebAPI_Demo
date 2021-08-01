using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Data.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SeoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SeoTitle = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSuppliers",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSuppliers", x => new { x.ProductId, x.SupplierId });
                    table.ForeignKey(
                        name: "FK_ProductSuppliers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSuppliers_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SeoTitle" },
                values: new object[,]
                {
                    { 1, "Quần bò nam", "Quần bò nam" },
                    { 2, "Áo sơ mi nam", "Áo sơ mi nam" },
                    { 3, "Giày cao gót", "Giay cao gót" },
                    { 4, "Giày thể thao nữ", "Giày thể thao nữ" },
                    { 5, "Phụ kiện", "Phụ kiện" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Address", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("191f2fa3-6090-4cd1-b455-e5bb9952fc56"), "New York", "Adidas", "0901534643" },
                    { new Guid("9aa6fdb5-a28e-49e5-b3cc-2af2935c264c"), "New York", "Nike", "0901534643" },
                    { new Guid("b6d16c71-4095-429a-a5d8-6c426ce1d89e"), "New York", "Canifa", "0901534643" },
                    { new Guid("46daea1f-4cc9-4b8f-b5ac-8e868039fb42"), "Japan", "Uniquilo", "0901534643" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "OriginalPrice", "Price", "SeoTitle" },
                values: new object[,]
                {
                    { new Guid("007897e8-c8d5-4045-a374-f1e713b9d349"), 1, "Description", "Quần Jean nam cao cấp Hàn Quốc", 2000000m, 1500000m, "SeoTile" },
                    { new Guid("4ae4f1e4-f8a9-4686-9ae5-99636e3a9555"), 1, "Description", "Quần baggy nam", 2000000m, 1500000m, "SeoTile" },
                    { new Guid("41b542aa-b862-43ab-9f0a-95aa18509bcd"), 1, "Description", "Jean ống suông", 2000000m, 1500000m, "SeoTile" },
                    { new Guid("efff8436-5e87-4d1f-a433-6587bc15a630"), 1, "Description", "Quần jean không gấu", 2000000m, 1500000m, "SeoTile" },
                    { new Guid("73c40b20-3957-4cc3-b469-7bf8710da82e"), 2, "Description", "Áo sơ mi cổ đức", 2000000m, 1500000m, "SeoTile" },
                    { new Guid("0c64d061-eb9f-46cd-b764-784bd93f70d1"), 2, "Description", "Áo sơ mi cúc bấm", 2000000m, 1500000m, "SeoTile" },
                    { new Guid("3df19266-984c-4239-af67-32c79902bf88"), 2, "Description", "Áo sơ mi họa tiết cáo", 2000000m, 1500000m, "SeoTile" },
                    { new Guid("f8cee4d8-0786-416d-96fe-3f082be58b2b"), 3, "Description", "Guốc cao gót Quảng Châu", 2000000m, 1500000m, "SeoTile" },
                    { new Guid("4404ea65-0d55-41f7-9b59-7710e8dd5398"), 3, "Description", "Guốc mũi nhọn", 2000000m, 1500000m, "SeoTile" },
                    { new Guid("e8636a01-ca7c-4c7d-8f47-624fd31b5884"), 4, "Description", "Giày thể thao Unisex", 2000000m, 1500000m, "SeoTile" },
                    { new Guid("631ffa1e-9add-4f39-bb2b-8d2b23c872c9"), 4, "Description", "Giày ", 2000000m, 1500000m, "SeoTile" },
                    { new Guid("abcde8bb-2d0c-467c-a7ba-885c9c13c52b"), 5, "Description", "Đồng hồ nam cao cấp", 2000000m, 1500000m, "SeoTile" }
                });

            migrationBuilder.InsertData(
                table: "ProductSuppliers",
                columns: new[] { "ProductId", "SupplierId" },
                values: new object[,]
                {
                    { new Guid("007897e8-c8d5-4045-a374-f1e713b9d349"), new Guid("191f2fa3-6090-4cd1-b455-e5bb9952fc56") },
                    { new Guid("4ae4f1e4-f8a9-4686-9ae5-99636e3a9555"), new Guid("9aa6fdb5-a28e-49e5-b3cc-2af2935c264c") },
                    { new Guid("41b542aa-b862-43ab-9f0a-95aa18509bcd"), new Guid("9aa6fdb5-a28e-49e5-b3cc-2af2935c264c") },
                    { new Guid("efff8436-5e87-4d1f-a433-6587bc15a630"), new Guid("46daea1f-4cc9-4b8f-b5ac-8e868039fb42") },
                    { new Guid("73c40b20-3957-4cc3-b469-7bf8710da82e"), new Guid("9aa6fdb5-a28e-49e5-b3cc-2af2935c264c") },
                    { new Guid("0c64d061-eb9f-46cd-b764-784bd93f70d1"), new Guid("191f2fa3-6090-4cd1-b455-e5bb9952fc56") },
                    { new Guid("3df19266-984c-4239-af67-32c79902bf88"), new Guid("9aa6fdb5-a28e-49e5-b3cc-2af2935c264c") },
                    { new Guid("f8cee4d8-0786-416d-96fe-3f082be58b2b"), new Guid("b6d16c71-4095-429a-a5d8-6c426ce1d89e") },
                    { new Guid("4404ea65-0d55-41f7-9b59-7710e8dd5398"), new Guid("191f2fa3-6090-4cd1-b455-e5bb9952fc56") },
                    { new Guid("e8636a01-ca7c-4c7d-8f47-624fd31b5884"), new Guid("46daea1f-4cc9-4b8f-b5ac-8e868039fb42") },
                    { new Guid("631ffa1e-9add-4f39-bb2b-8d2b23c872c9"), new Guid("191f2fa3-6090-4cd1-b455-e5bb9952fc56") },
                    { new Guid("abcde8bb-2d0c-467c-a7ba-885c9c13c52b"), new Guid("46daea1f-4cc9-4b8f-b5ac-8e868039fb42") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSuppliers_SupplierId",
                table: "ProductSuppliers",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSuppliers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
