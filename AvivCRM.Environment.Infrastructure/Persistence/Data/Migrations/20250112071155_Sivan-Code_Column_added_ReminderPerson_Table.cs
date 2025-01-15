using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvivCRM.Environment.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SivanCode_Column_added_ReminderPerson_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                schema: "aviv",
                table: "tblRecruitCustomQuestionSetting",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "aviv",
                table: "tblRecruitCustomQuestionSetting",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "aviv",
                table: "tblProjectReminderPerson",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                schema: "aviv",
                table: "tblProjectReminderPerson");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                schema: "aviv",
                table: "tblRecruitCustomQuestionSetting",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "aviv",
                table: "tblRecruitCustomQuestionSetting",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETUTCDATE()");
        }
    }
}
