using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvivCRM.Environment.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SivanRecruit_Table_Relationship_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "aviv",
                table: "tblRecruitJobApplicationStatusSetting",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Question",
                schema: "aviv",
                table: "tblRecruitCustomQuestionSetting",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "aviv",
                table: "tblJobApplicationPosition",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "aviv",
                table: "tblJobApplicationPosition",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "aviv",
                table: "tblJobApplicationCategory",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "aviv",
                table: "tblJobApplicationCategory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "aviv",
                table: "tblCustomQuestionType",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "aviv",
                table: "tblCustomQuestionType",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "aviv",
                table: "tblCustomQuestionCategory",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "aviv",
                table: "tblCustomQuestionCategory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblRecruitJobApplicationStatusSetting_CategoryId",
                schema: "aviv",
                table: "tblRecruitJobApplicationStatusSetting",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRecruitJobApplicationStatusSetting_PositionId",
                schema: "aviv",
                table: "tblRecruitJobApplicationStatusSetting",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRecruitCustomQuestionSetting_CategoryId",
                schema: "aviv",
                table: "tblRecruitCustomQuestionSetting",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRecruitCustomQuestionSetting_StatusId",
                schema: "aviv",
                table: "tblRecruitCustomQuestionSetting",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRecruitCustomQuestionSetting_TypeId",
                schema: "aviv",
                table: "tblRecruitCustomQuestionSetting",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblRecruitCustomQuestionSetting_tblCustomQuestionCategory_CategoryId",
                schema: "aviv",
                table: "tblRecruitCustomQuestionSetting",
                column: "CategoryId",
                principalSchema: "aviv",
                principalTable: "tblCustomQuestionCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblRecruitCustomQuestionSetting_tblCustomQuestionType_TypeId",
                schema: "aviv",
                table: "tblRecruitCustomQuestionSetting",
                column: "TypeId",
                principalSchema: "aviv",
                principalTable: "tblCustomQuestionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblRecruitCustomQuestionSetting_tblToggleValue_StatusId",
                schema: "aviv",
                table: "tblRecruitCustomQuestionSetting",
                column: "StatusId",
                principalSchema: "aviv",
                principalTable: "tblToggleValue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblRecruitJobApplicationStatusSetting_tblJobApplicationCategory_CategoryId",
                schema: "aviv",
                table: "tblRecruitJobApplicationStatusSetting",
                column: "CategoryId",
                principalSchema: "aviv",
                principalTable: "tblJobApplicationCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblRecruitJobApplicationStatusSetting_tblJobApplicationPosition_PositionId",
                schema: "aviv",
                table: "tblRecruitJobApplicationStatusSetting",
                column: "PositionId",
                principalSchema: "aviv",
                principalTable: "tblJobApplicationPosition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblRecruitCustomQuestionSetting_tblCustomQuestionCategory_CategoryId",
                schema: "aviv",
                table: "tblRecruitCustomQuestionSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRecruitCustomQuestionSetting_tblCustomQuestionType_TypeId",
                schema: "aviv",
                table: "tblRecruitCustomQuestionSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRecruitCustomQuestionSetting_tblToggleValue_StatusId",
                schema: "aviv",
                table: "tblRecruitCustomQuestionSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRecruitJobApplicationStatusSetting_tblJobApplicationCategory_CategoryId",
                schema: "aviv",
                table: "tblRecruitJobApplicationStatusSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_tblRecruitJobApplicationStatusSetting_tblJobApplicationPosition_PositionId",
                schema: "aviv",
                table: "tblRecruitJobApplicationStatusSetting");

            migrationBuilder.DropIndex(
                name: "IX_tblRecruitJobApplicationStatusSetting_CategoryId",
                schema: "aviv",
                table: "tblRecruitJobApplicationStatusSetting");

            migrationBuilder.DropIndex(
                name: "IX_tblRecruitJobApplicationStatusSetting_PositionId",
                schema: "aviv",
                table: "tblRecruitJobApplicationStatusSetting");

            migrationBuilder.DropIndex(
                name: "IX_tblRecruitCustomQuestionSetting_CategoryId",
                schema: "aviv",
                table: "tblRecruitCustomQuestionSetting");

            migrationBuilder.DropIndex(
                name: "IX_tblRecruitCustomQuestionSetting_StatusId",
                schema: "aviv",
                table: "tblRecruitCustomQuestionSetting");

            migrationBuilder.DropIndex(
                name: "IX_tblRecruitCustomQuestionSetting_TypeId",
                schema: "aviv",
                table: "tblRecruitCustomQuestionSetting");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "aviv",
                table: "tblRecruitJobApplicationStatusSetting",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Question",
                schema: "aviv",
                table: "tblRecruitCustomQuestionSetting",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "aviv",
                table: "tblJobApplicationPosition",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "aviv",
                table: "tblJobApplicationPosition",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "aviv",
                table: "tblJobApplicationCategory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "aviv",
                table: "tblJobApplicationCategory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "aviv",
                table: "tblCustomQuestionType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "aviv",
                table: "tblCustomQuestionType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "aviv",
                table: "tblCustomQuestionCategory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "aviv",
                table: "tblCustomQuestionCategory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);
        }
    }
}
