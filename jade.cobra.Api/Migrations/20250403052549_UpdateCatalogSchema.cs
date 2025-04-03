using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jade.cobra.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCatalogSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Brand", "Description", "Name", "Price" },
                values: new object[] { 3, "Nike", "Ohio State shoes", "Shoes", 129.99m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
