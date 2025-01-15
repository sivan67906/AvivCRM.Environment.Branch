using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvivCRM.Environment.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SivanTicket_Tbl_Relationship_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "aviv",
                table: "tblTicketAgent",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                schema: "aviv",
                table: "tblTicketAgent",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "aviv",
                table: "tblTicketAgent",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                schema: "aviv",
                table: "tblTicketAgent",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                schema: "aviv",
                table: "tblTicketAgent",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TypeId",
                schema: "aviv",
                table: "tblTicketAgent",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tblTicketAgent_GroupId",
                schema: "aviv",
                table: "tblTicketAgent",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTicketAgent_StatusId",
                schema: "aviv",
                table: "tblTicketAgent",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTicketAgent_TypeId",
                schema: "aviv",
                table: "tblTicketAgent",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblTicketAgent_tblTicketGroup_GroupId",
                schema: "aviv",
                table: "tblTicketAgent",
                column: "GroupId",
                principalSchema: "aviv",
                principalTable: "tblTicketGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblTicketAgent_tblTicketType_TypeId",
                schema: "aviv",
                table: "tblTicketAgent",
                column: "TypeId",
                principalSchema: "aviv",
                principalTable: "tblTicketType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblTicketAgent_tblToggleValue_StatusId",
                schema: "aviv",
                table: "tblTicketAgent",
                column: "StatusId",
                principalSchema: "aviv",
                principalTable: "tblToggleValue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblTicketAgent_tblTicketGroup_GroupId",
                schema: "aviv",
                table: "tblTicketAgent");

            migrationBuilder.DropForeignKey(
                name: "FK_tblTicketAgent_tblTicketType_TypeId",
                schema: "aviv",
                table: "tblTicketAgent");

            migrationBuilder.DropForeignKey(
                name: "FK_tblTicketAgent_tblToggleValue_StatusId",
                schema: "aviv",
                table: "tblTicketAgent");

            migrationBuilder.DropIndex(
                name: "IX_tblTicketAgent_GroupId",
                schema: "aviv",
                table: "tblTicketAgent");

            migrationBuilder.DropIndex(
                name: "IX_tblTicketAgent_StatusId",
                schema: "aviv",
                table: "tblTicketAgent");

            migrationBuilder.DropIndex(
                name: "IX_tblTicketAgent_TypeId",
                schema: "aviv",
                table: "tblTicketAgent");

            migrationBuilder.DropColumn(
                name: "GroupId",
                schema: "aviv",
                table: "tblTicketAgent");

            migrationBuilder.DropColumn(
                name: "StatusId",
                schema: "aviv",
                table: "tblTicketAgent");

            migrationBuilder.DropColumn(
                name: "TypeId",
                schema: "aviv",
                table: "tblTicketAgent");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "aviv",
                table: "tblTicketAgent",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                schema: "aviv",
                table: "tblTicketAgent",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "aviv",
                table: "tblTicketAgent",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETUTCDATE()");
        }
    }
}
