using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvivCRM.Environment.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SivanRecruitFooter_Table_ColumnName_Renamed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "aviv",
                table: "tblRecruitFooterSetting");

            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                schema: "aviv",
                table: "tblRecruitFooterSetting",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusId",
                schema: "aviv",
                table: "tblRecruitFooterSetting");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                schema: "aviv",
                table: "tblRecruitFooterSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
