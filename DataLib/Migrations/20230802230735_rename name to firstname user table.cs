using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLib.Migrations
{
    /// <inheritdoc />
    public partial class renamenametofirstnameusertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_UserId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_UserId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.CreateTable(
                name: "ProfileImage",
                columns: table => new
                {
                    UserImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageBytes = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileImage", x => x.UserImageId);
                    table.ForeignKey(
                        name: "FK_ProfileImage_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ItemLists",
                keyColumn: "ItemListId",
                keyValue: 1,
                column: "ItemListType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ItemLists",
                keyColumn: "ItemListId",
                keyValue: 2,
                column: "ItemListType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ItemLists",
                keyColumn: "ItemListId",
                keyValue: 3,
                column: "ItemListType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ItemLists",
                keyColumn: "ItemListId",
                keyValue: 4,
                column: "ItemListType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ItemLists",
                keyColumn: "ItemListId",
                keyValue: 5,
                column: "ItemListType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ItemLists",
                keyColumn: "ItemListId",
                keyValue: 6,
                column: "ItemListType",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileImage_UserId",
                table: "ProfileImage",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileImage");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Users",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ItemLists",
                keyColumn: "ItemListId",
                keyValue: 1,
                column: "ItemListType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ItemLists",
                keyColumn: "ItemListId",
                keyValue: 2,
                column: "ItemListType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ItemLists",
                keyColumn: "ItemListId",
                keyValue: 3,
                column: "ItemListType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ItemLists",
                keyColumn: "ItemListId",
                keyValue: 4,
                column: "ItemListType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ItemLists",
                keyColumn: "ItemListId",
                keyValue: 5,
                column: "ItemListType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ItemLists",
                keyColumn: "ItemListId",
                keyValue: 6,
                column: "ItemListType",
                value: 2);

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
                name: "IX_Items_UserId",
                table: "Items",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_UserId",
                table: "Items",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
