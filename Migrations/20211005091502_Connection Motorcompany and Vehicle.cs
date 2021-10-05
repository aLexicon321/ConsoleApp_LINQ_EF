using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp_LINQ.Migrations
{
    public partial class ConnectionMotorcompanyandVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Companies_MotorCompanyId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_Companies_MotorCompanyId",
                table: "Motorcycles");

            migrationBuilder.AlterColumn<int>(
                name: "MotorCompanyId",
                table: "Motorcycles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MotorCompanyId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Companies_MotorCompanyId",
                table: "Cars",
                column: "MotorCompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_Companies_MotorCompanyId",
                table: "Motorcycles",
                column: "MotorCompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Companies_MotorCompanyId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_Companies_MotorCompanyId",
                table: "Motorcycles");

            migrationBuilder.AlterColumn<int>(
                name: "MotorCompanyId",
                table: "Motorcycles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MotorCompanyId",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
