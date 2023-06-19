using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Saas.Admin.Service.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationRolesAdded_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationId",
                table: "Subscriptions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Applications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applications",
                table: "Applications",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { new Guid("8924f18e-de16-4963-b596-d6ba22dc8d5a"), "Financial services", "financial.topal.ch" },
                    { new Guid("8bf68f28-11dd-4fff-a88f-38c832812503"), "Payroll services", "payroll.topal.ch" }
                });

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApplicationId",
                value: new Guid("8924f18e-de16-4963-b596-d6ba22dc8d5a"));

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 2,
                column: "ApplicationId",
                value: new Guid("8924f18e-de16-4963-b596-d6ba22dc8d5a"));

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 3,
                column: "ApplicationId",
                value: new Guid("8924f18e-de16-4963-b596-d6ba22dc8d5a"));

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 4,
                column: "ApplicationId",
                value: new Guid("8924f18e-de16-4963-b596-d6ba22dc8d5a"));

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 5,
                column: "ApplicationId",
                value: new Guid("8bf68f28-11dd-4fff-a88f-38c832812503"));

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 6,
                column: "ApplicationId",
                value: new Guid("8bf68f28-11dd-4fff-a88f-38c832812503"));

            migrationBuilder.CreateIndex(
                name: "IX_TenantApplicationRoles_ApplicationId",
                table: "TenantApplicationRoles",
                column: "ApplicationId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TenantApplicationRoles_Applications_ApplicationId",
                table: "TenantApplicationRoles",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Applications_ApplicationId",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantApplicationRoles_Applications_ApplicationId",
                table: "TenantApplicationRoles");

            migrationBuilder.DropIndex(
                name: "IX_TenantApplicationRoles_ApplicationId",
                table: "TenantApplicationRoles");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_ApplicationId",
                table: "Subscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applications",
                table: "Applications");

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("8924f18e-de16-4963-b596-d6ba22dc8d5a"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("8bf68f28-11dd-4fff-a88f-38c832812503"));

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Applications");
        }
    }
}
