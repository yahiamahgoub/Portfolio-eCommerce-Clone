using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLib.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemList_Users_UserId",
                table: "ItemList");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemListToItemJoin_ItemList_ItemListId",
                table: "ItemListToItemJoin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemList",
                table: "ItemList");

            migrationBuilder.RenameTable(
                name: "ItemList",
                newName: "ItemLists");

            migrationBuilder.RenameIndex(
                name: "IX_ItemList_UserId",
                table: "ItemLists",
                newName: "IX_ItemLists_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemLists",
                table: "ItemLists",
                column: "ItemListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemLists_Users_UserId",
                table: "ItemLists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemListToItemJoin_ItemLists_ItemListId",
                table: "ItemListToItemJoin",
                column: "ItemListId",
                principalTable: "ItemLists",
                principalColumn: "ItemListId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemLists_Users_UserId",
                table: "ItemLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemListToItemJoin_ItemLists_ItemListId",
                table: "ItemListToItemJoin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemLists",
                table: "ItemLists");

            migrationBuilder.RenameTable(
                name: "ItemLists",
                newName: "ItemList");

            migrationBuilder.RenameIndex(
                name: "IX_ItemLists_UserId",
                table: "ItemList",
                newName: "IX_ItemList_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemList",
                table: "ItemList",
                column: "ItemListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemList_Users_UserId",
                table: "ItemList",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemListToItemJoin_ItemList_ItemListId",
                table: "ItemListToItemJoin",
                column: "ItemListId",
                principalTable: "ItemList",
                principalColumn: "ItemListId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
