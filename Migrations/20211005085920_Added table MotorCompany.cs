using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp_LINQ.Migrations
{
    public partial class AddedtableMotorCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MotorCompanyId",
                table: "Motorcycles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MotorCompanyId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_MotorCompanyId",
                table: "Motorcycles",
                column: "MotorCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_MotorCompanyId",
                table: "Cars",
                column: "MotorCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Companies_MotorCompanyId",
                table: "Cars",
                column: "MotorCompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_Companies_MotorCompanyId",
                table: "Motorcycles",
                column: "MotorCompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Companies_MotorCompanyId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_Companies_MotorCompanyId",
                table: "Motorcycles");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Motorcycles_MotorCompanyId",
                table: "Motorcycles");

            migrationBuilder.DropIndex(
                name: "IX_Cars_MotorCompanyId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "MotorCompanyId",
                table: "Motorcycles");

            migrationBuilder.DropColumn(
                name: "MotorCompanyId",
                table: "Cars");
        }
    }
}
