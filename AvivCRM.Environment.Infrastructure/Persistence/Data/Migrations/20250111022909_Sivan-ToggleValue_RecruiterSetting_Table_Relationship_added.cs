using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvivCRM.Environment.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SivanToggleValue_RecruiterSetting_Table_Relationship_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "aviv",
                table: "tblRecruiterSetting");

            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                schema: "aviv",
                table: "tblRecruiterSetting",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tblRecruiterSetting_StatusId",
                schema: "aviv",
                table: "tblRecruiterSetting",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblRecruiterSetting_tblToggleValue_StatusId",
                schema: "aviv",
                table: "tblRecruiterSetting",
                column: "StatusId",
                principalSchema: "aviv",
                principalTable: "tblToggleValue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblRecruiterSetting_tblToggleValue_StatusId",
                schema: "aviv",
                table: "tblRecruiterSetting");

            migrationBuilder.DropIndex(
                name: "IX_tblRecruiterSetting_StatusId",
                schema: "aviv",
                table: "tblRecruiterSetting");

            migrationBuilder.DropColumn(
                name: "StatusId",
                schema: "aviv",
                table: "tblRecruiterSetting");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                schema: "aviv",
                table: "tblRecruiterSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
