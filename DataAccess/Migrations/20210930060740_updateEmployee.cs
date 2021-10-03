using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class updateEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeeMonthlyPayments_Employee_ID",
                table: "EmployeeMonthlyPayments");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMonthlyPayments_Employee_ID",
                table: "EmployeeMonthlyPayments",
                column: "Employee_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeeMonthlyPayments_Employee_ID",
                table: "EmployeeMonthlyPayments");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMonthlyPayments_Employee_ID",
                table: "EmployeeMonthlyPayments",
                column: "Employee_ID",
                unique: true);
        }
    }
}
