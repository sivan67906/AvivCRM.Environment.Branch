using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvivCRM.Environment.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SivanToggleValue_Table_Added_for_Common_YesNo_Functionality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblToggleValue",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblToggleValue", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblToggleValue",
                schema: "aviv");
        }
    }
}
