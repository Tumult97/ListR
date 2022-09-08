using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListR.DataLayer.Migrations
{
    public partial class editmappingsid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_listItems_ShopLists_ShopListId",
                table: "listItems");

            migrationBuilder.DropColumn(
                name: "ListId",
                table: "listItems");

            migrationBuilder.AlterColumn<int>(
                name: "ShopListId",
                table: "listItems",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_listItems_ShopLists_ShopListId",
                table: "listItems",
                column: "ShopListId",
                principalTable: "ShopLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_listItems_ShopLists_ShopListId",
                table: "listItems");

            migrationBuilder.AlterColumn<int>(
                name: "ShopListId",
                table: "listItems",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "ListId",
                table: "listItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_listItems_ShopLists_ShopListId",
                table: "listItems",
                column: "ShopListId",
                principalTable: "ShopLists",
                principalColumn: "Id");
        }
    }
}
