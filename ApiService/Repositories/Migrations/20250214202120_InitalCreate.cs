using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppApplications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaimDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedUserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    FalseEntryCount = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppMenus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppId = table.Column<int>(type: "int", nullable: false),
                    MenuName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenuDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppClaimId = table.Column<int>(type: "int", nullable: false),
                    AppApplicationsId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppMenus_AppApplications_AppApplicationsId",
                        column: x => x.AppApplicationsId,
                        principalTable: "AppApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppMenus_AppClaims_AppClaimId",
                        column: x => x.AppClaimId,
                        principalTable: "AppClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "AppTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppTokens_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    AppClaimId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserClaims_AppClaims_AppClaimId",
                        column: x => x.AppClaimId,
                        principalTable: "AppClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserClaims_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserRoles_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserRoles_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppClaimAppRoleClaim_AppRoleClaimsId",
                table: "AppClaimAppRoleClaim",
                column: "AppRoleClaimsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppMenus_AppApplicationsId",
                table: "AppMenus",
                column: "AppApplicationsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppMenus_AppClaimId",
                table: "AppMenus",
                column: "AppClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleAppRoleClaim_AppRolesId",
                table: "AppRoleAppRoleClaim",
                column: "AppRolesId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTokens_AppUserId",
                table: "AppTokens",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUserClaims_AppClaimId",
                table: "AppUserClaims",
                column: "AppClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserClaims_AppUserId",
                table: "AppUserClaims",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRoles_AppUserId",
                table: "AppUserRoles",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRoles_RoleId",
                table: "AppUserRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppClaimAppRoleClaim");

            migrationBuilder.DropTable(
                name: "AppMenus");

            migrationBuilder.DropTable(
                name: "AppRoleAppRoleClaim");

            migrationBuilder.DropTable(
                name: "AppTokens");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppApplications");

            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppClaims");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
