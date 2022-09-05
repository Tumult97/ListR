using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ListR.DataLayer.Migrations
{
    public partial class AddedMappingToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserGroups_UserGroupId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroupMappings",
                table: "UserGroupMappings");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserGroupId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserGroupMappings");

            migrationBuilder.DropColumn(
                name: "UserGroupId",
                table: "AspNetUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroupMappings",
                table: "UserGroupMappings",
                columns: new[] { "UserGroupsId", "UsersId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupMappings_UsersId",
                table: "UserGroupMappings",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroupMappings_AspNetUsers_UsersId",
                table: "UserGroupMappings",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroupMappings_UserGroups_UserGroupsId",
                table: "UserGroupMappings",
                column: "UserGroupsId",
                principalTable: "UserGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroupMappings_AspNetUsers_UsersId",
                table: "UserGroupMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroupMappings_UserGroups_UserGroupsId",
                table: "UserGroupMappings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroupMappings",
                table: "UserGroupMappings");

            migrationBuilder.DropIndex(
                name: "IX_UserGroupMappings_UsersId",
                table: "UserGroupMappings");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserGroupMappings",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "UserGroupId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroupMappings",
                table: "UserGroupMappings",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserGroupId",
                table: "AspNetUsers",
                column: "UserGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserGroups_UserGroupId",
                table: "AspNetUsers",
                column: "UserGroupId",
                principalTable: "UserGroups",
                principalColumn: "Id");
        }
    }
}
