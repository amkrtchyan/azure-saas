using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Saas.Admin.Service.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationRolesAdded_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Applications_ApplicationId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_ApplicationId",
                table: "Subscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applications",
                table: "Applications");

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Applications");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tenants",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorEmail",
                table: "Tenants",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Tenants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TenantApplicationRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantApplicationRoles", x => x.Id);
                    table.UniqueConstraint("AK_TenantApplicationRoles_Id_TenantId", x => new { x.Id, x.TenantId });
                    table.UniqueConstraint("AK_TenantApplicationRoles_TenantId_ApplicationId_Role", x => new { x.TenantId, x.ApplicationId, x.Role });
                });

            migrationBuilder.CreateTable(
                name: "TenantUserRoles",
                columns: table => new
                {
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantUserRoles", x => new { x.TenantId, x.UserId, x.ApplicationRoleId });
                    table.ForeignKey(
                        name: "FK_TenantUserRoles_TenantApplicationRoles_ApplicationRoleId_TenantId",
                        columns: x => new { x.ApplicationRoleId, x.TenantId },
                        principalTable: "TenantApplicationRoles",
                        principalColumns: new[] { "Id", "TenantId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantUserRoles_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TenantUserRoles_ApplicationRoleId_TenantId",
                table: "TenantUserRoles",
                columns: new[] { "ApplicationRoleId", "TenantId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenantUserRoles");

            migrationBuilder.DropTable(
                name: "TenantApplicationRoles");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tenants");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CreatorEmail",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                table: "Subscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applications",
                table: "Applications",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Financial services", "financial.topal.ch" },
                    { 2, "Payroll services", "payroll.topal.ch" }
                });

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApplicationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 2,
                column: "ApplicationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 3,
                column: "ApplicationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 4,
                column: "ApplicationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 5,
                column: "ApplicationId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 6,
                column: "ApplicationId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_ApplicationId",
                table: "Subscriptions",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Applications_ApplicationId",
                table: "Subscriptions",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
