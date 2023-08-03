using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLib.Migrations
{
    /// <inheritdoc />
    public partial class seedlistsdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ItemList",
                columns: new[] { "ItemListId", "ItemListType", "ListName", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "ForSaleByUser", 1 },
                    { 2, 0, "FavoriteByUser", 1 },
                    { 3, 1, "ForSaleByUser", 2 },
                    { 4, 0, "FavoriteByUser", 2 },
                    { 5, 1, "ForSaleByUser", 3 },
                    { 6, 0, "FavoriteByUser", 3 }
                });

            migrationBuilder.InsertData(
                table: "ItemListToItemJoin",
                columns: new[] { "ItemId", "ItemListId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemList",
                keyColumn: "ItemListId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ItemList",
                keyColumn: "ItemListId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ItemList",
                keyColumn: "ItemListId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ItemList",
                keyColumn: "ItemListId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ItemList",
                keyColumn: "ItemListId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ItemListToItemJoin",
                keyColumns: new[] { "ItemId", "ItemListId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ItemListToItemJoin",
                keyColumns: new[] { "ItemId", "ItemListId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ItemList",
                keyColumn: "ItemListId",
                keyValue: 1);
        }
    }
}
