using Microsoft.EntityFrameworkCore.Migrations;

namespace Pi.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Appusers",
                columns: new[] { "Id", "IsDelete", "Name", "SurName" },
                values: new object[] { 1, false, "Testname", "Testsurname" });

            migrationBuilder.InsertData(
                table: "Appusers",
                columns: new[] { "Id", "IsDelete", "Name", "SurName" },
                values: new object[] { 2, false, "Testname2", "Testsurname2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appusers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appusers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
