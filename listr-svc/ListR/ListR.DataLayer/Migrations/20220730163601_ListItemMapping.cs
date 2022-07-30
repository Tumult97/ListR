using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListR.DataLayer.Migrations
{
    public partial class ListItemMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShopListId",
                table: "listItems",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_listItems_ShopListId",
                table: "listItems",
                column: "ShopListId");

            migrationBuilder.AddForeignKey(
                name: "FK_listItems_ShopLists_ShopListId",
                table: "listItems",
                column: "ListId",
                principalTable: "ShopLists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_listItems_ShopLists_ShopListId",
                table: "listItems");

            migrationBuilder.DropIndex(
                name: "IX_listItems_ShopListId",
                table: "listItems");

            migrationBuilder.DropColumn(
                name: "ShopListId",
                table: "listItems");
        }
    }
}
