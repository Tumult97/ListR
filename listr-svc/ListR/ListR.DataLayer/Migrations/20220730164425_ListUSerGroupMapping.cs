using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListR.DataLayer.Migrations
{
    public partial class ListUSerGroupMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ShopLists_UserGroupId",
                table: "ShopLists",
                column: "UserGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopLists_UserGroups_UserGroupId",
                table: "ShopLists",
                column: "UserGroupId",
                principalTable: "UserGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopLists_UserGroups_UserGroupId",
                table: "ShopLists");

            migrationBuilder.DropIndex(
                name: "IX_ShopLists_UserGroupId",
                table: "ShopLists");
        }
    }
}
