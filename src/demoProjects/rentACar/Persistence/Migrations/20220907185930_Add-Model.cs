using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DailyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "DailyPrice", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, 1, 1899.99m, "", "911" },
                    { 2, 1, 1699.99m, "", "Cayman" },
                    { 3, 2, 1299.99m, "", "C-Class" },
                    { 4, 2, 1499.99m, "", "E-Class" +
                    "" },
                    { 5, 3, 1399.99m, "", "Guilia" },
                    { 6, 3, 1499.99m, "", "Stelvio" },
                    { 7, 4, 1499.99m, "", "Series 5" },
                    { 8, 4, 999.99m, "", "Series 1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Models");
        }
    }
}
