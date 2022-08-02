using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ListR.DataLayer.Migrations
{
    public partial class AddMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "UserCreatedBy",
                table: "UserGroups",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserGroupMappings",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroupMappings",
                table: "UserGroupMappings",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserUserGroup",
                columns: table => new
                {
                    UserGroupsId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUserGroup", x => new { x.UserGroupsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserUserGroup_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUserGroup_UserGroups_UserGroupsId",
                        column: x => x.UserGroupsId,
                        principalTable: "UserGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserUserGroup_UsersId",
                table: "UserUserGroup",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserUserGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroupMappings",
                table: "UserGroupMappings");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserGroupMappings");

            migrationBuilder.AlterColumn<string>(
                name: "UserCreatedBy",
                table: "UserGroups",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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
    }
}
