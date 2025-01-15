using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvivCRM.Environment.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SivanadditionalColumnAdded_Recruiter_Page : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "aviv",
                table: "tblJobApplicationPosition",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "aviv",
                table: "tblJobApplicationCategory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "aviv",
                table: "tblCustomQuestionType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "aviv",
                table: "tblCustomQuestionCategory",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                schema: "aviv",
                table: "tblJobApplicationPosition");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "aviv",
                table: "tblJobApplicationCategory");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "aviv",
                table: "tblCustomQuestionType");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "aviv",
                table: "tblCustomQuestionCategory");
        }
    }
}
