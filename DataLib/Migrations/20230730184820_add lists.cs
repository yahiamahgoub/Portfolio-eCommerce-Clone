using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLib.Migrations
{
    /// <inheritdoc />
    public partial class addlists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_UserId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "ItemList",
                columns: table => new
                {
                    ItemListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemListType = table.Column<int>(type: "int", nullable: false),
                    ListName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemList", x => x.ItemListId);
                    table.ForeignKey(
                        name: "FK_ItemList_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemListToItemJoin",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ItemListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemListToItemJoin", x => new { x.ItemId, x.ItemListId });
                    table.ForeignKey(
                        name: "FK_ItemListToItemJoin_ItemList_ItemListId",
                        column: x => x.ItemListId,
                        principalTable: "ItemList",
                        principalColumn: "ItemListId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemListToItemJoin_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 2,
                column: "UserId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_ItemList_UserId",
                table: "ItemList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemListToItemJoin_ItemListId",
                table: "ItemListToItemJoin",
                column: "ItemListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_UserId",
                table: "Items",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_UserId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "ItemListToItemJoin");

            migrationBuilder.DropTable(
                name: "ItemList");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 2,
                column: "UserId",
                value: 2);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_UserId",
                table: "Items",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
