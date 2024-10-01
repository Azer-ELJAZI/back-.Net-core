using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace stage1.Migrations
{
    public partial class @as : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServiceCaseId",
                table: "ServiceCases",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ServiceCases",
                newName: "ServiceCaseId");
        }
    }
}
