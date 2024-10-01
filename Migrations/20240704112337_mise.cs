using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace stage1.Migrations
{
    public partial class mise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCases_Companies_CompanyId",
                table: "ServiceCases");

            migrationBuilder.DropIndex(
                name: "IX_ServiceCases_CompanyId",
                table: "ServiceCases");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "ServiceCases",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ServiceCases",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "AffectedCompany",
                table: "ServiceCases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AffectedInstallation",
                table: "ServiceCases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Checklist",
                table: "ServiceCases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactPerson",
                table: "ServiceCases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Element",
                table: "ServiceCases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "ServiceCases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OriginatingJob",
                table: "ServiceCases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OriginatingServiceOrder",
                table: "ServiceCases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "ServiceCases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResponsibleUser",
                table: "ServiceCases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ServiceCaseCategory",
                table: "ServiceCases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ServiceCaseNo",
                table: "ServiceCases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ServiceCaseTemplate",
                table: "ServiceCases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ServiceObject",
                table: "ServiceCases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "ServiceCases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Visibility",
                table: "ServiceCases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AffectedCompany",
                table: "ServiceCases");

            migrationBuilder.DropColumn(
                name: "AffectedInstallation",
                table: "ServiceCases");

            migrationBuilder.DropColumn(
                name: "Checklist",
                table: "ServiceCases");

            migrationBuilder.DropColumn(
                name: "ContactPerson",
                table: "ServiceCases");

            migrationBuilder.DropColumn(
                name: "Element",
                table: "ServiceCases");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "ServiceCases");

            migrationBuilder.DropColumn(
                name: "OriginatingJob",
                table: "ServiceCases");

            migrationBuilder.DropColumn(
                name: "OriginatingServiceOrder",
                table: "ServiceCases");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "ServiceCases");

            migrationBuilder.DropColumn(
                name: "ResponsibleUser",
                table: "ServiceCases");

            migrationBuilder.DropColumn(
                name: "ServiceCaseCategory",
                table: "ServiceCases");

            migrationBuilder.DropColumn(
                name: "ServiceCaseNo",
                table: "ServiceCases");

            migrationBuilder.DropColumn(
                name: "ServiceCaseTemplate",
                table: "ServiceCases");

            migrationBuilder.DropColumn(
                name: "ServiceObject",
                table: "ServiceCases");

            migrationBuilder.DropColumn(
                name: "Skills",
                table: "ServiceCases");

            migrationBuilder.DropColumn(
                name: "Visibility",
                table: "ServiceCases");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "ServiceCases",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ServiceCases",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCases_CompanyId",
                table: "ServiceCases",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCases_Companies_CompanyId",
                table: "ServiceCases",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
