using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListR.DataLayer.Migrations
{
    public partial class ChangeOnetoOnOnListUserGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShopLists_UserGroupId",
                table: "ShopLists");

            migrationBuilder.CreateIndex(
                name: "IX_ShopLists_UserGroupId",
                table: "ShopLists",
                column: "UserGroupId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShopLists_UserGroupId",
                table: "ShopLists");

            migrationBuilder.CreateIndex(
                name: "IX_ShopLists_UserGroupId",
                table: "ShopLists",
                column: "UserGroupId");
        }
    }
}
