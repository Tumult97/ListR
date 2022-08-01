using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListR.DataLayer.Migrations
{
    public partial class ChangeUserIdToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShopLists_UserGroupId",
                table: "ShopLists");

            migrationBuilder.AlterColumn<string>(
                name: "UserCreatedBy",
                table: "UserGroups",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_ShopLists_UserGroupId",
                table: "ShopLists",
                column: "UserGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShopLists_UserGroupId",
                table: "ShopLists");

            migrationBuilder.AlterColumn<int>(
                name: "UserCreatedBy",
                table: "UserGroups",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_ShopLists_UserGroupId",
                table: "ShopLists",
                column: "UserGroupId",
                unique: true);
        }
    }
}
