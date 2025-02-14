using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class IntitalDeclare2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppClaimAppRoleClaim");

            migrationBuilder.DropTable(
                name: "AppRoleAppRoleClaim");

            migrationBuilder.AddColumn<int>(
                name: "AppClaimsId",
                table: "AppRoleClaims",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppRolesId",
                table: "AppRoleClaims",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleClaims_AppClaimsId",
                table: "AppRoleClaims",
                column: "AppClaimsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleClaims_AppRolesId",
                table: "AppRoleClaims",
                column: "AppRolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppRoleClaims_AppClaims_AppClaimsId",
                table: "AppRoleClaims",
                column: "AppClaimsId",
                principalTable: "AppClaims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppRoleClaims_AppRoles_AppRolesId",
                table: "AppRoleClaims",
                column: "AppRolesId",
                principalTable: "AppRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppRoleClaims_AppClaims_AppClaimsId",
                table: "AppRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AppRoleClaims_AppRoles_AppRolesId",
                table: "AppRoleClaims");

            migrationBuilder.DropIndex(
                name: "IX_AppRoleClaims_AppClaimsId",
                table: "AppRoleClaims");

            migrationBuilder.DropIndex(
                name: "IX_AppRoleClaims_AppRolesId",
                table: "AppRoleClaims");

            migrationBuilder.DropColumn(
                name: "AppClaimsId",
                table: "AppRoleClaims");

            migrationBuilder.DropColumn(
                name: "AppRolesId",
                table: "AppRoleClaims");

            migrationBuilder.CreateTable(
                name: "AppClaimAppRoleClaim",
                columns: table => new
                {
                    AppClaimsId = table.Column<int>(type: "int", nullable: false),
                    AppRoleClaimsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppClaimAppRoleClaim", x => new { x.AppClaimsId, x.AppRoleClaimsId });
                    table.ForeignKey(
                        name: "FK_AppClaimAppRoleClaim_AppClaims_AppClaimsId",
                        column: x => x.AppClaimsId,
                        principalTable: "AppClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppClaimAppRoleClaim_AppRoleClaims_AppRoleClaimsId",
                        column: x => x.AppRoleClaimsId,
                        principalTable: "AppRoleClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppRoleAppRoleClaim",
                columns: table => new
                {
                    AppRoleClaimsId = table.Column<int>(type: "int", nullable: false),
                    AppRolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleAppRoleClaim", x => new { x.AppRoleClaimsId, x.AppRolesId });
                    table.ForeignKey(
                        name: "FK_AppRoleAppRoleClaim_AppRoleClaims_AppRoleClaimsId",
                        column: x => x.AppRoleClaimsId,
                        principalTable: "AppRoleClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppRoleAppRoleClaim_AppRoles_AppRolesId",
                        column: x => x.AppRolesId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppClaimAppRoleClaim_AppRoleClaimsId",
                table: "AppClaimAppRoleClaim",
                column: "AppRoleClaimsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleAppRoleClaim_AppRolesId",
                table: "AppRoleAppRoleClaim",
                column: "AppRolesId");
        }
    }
}
