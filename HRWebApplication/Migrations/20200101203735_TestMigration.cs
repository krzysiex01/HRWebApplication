using Microsoft.EntityFrameworkCore.Migrations;

namespace HRWebApplication.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Description", "Location", "Name" },
                values: new object[] { 1, "Some desctiption", "Warsaw", "Apple" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "CompanyId", "Country", "EmailAddress", "FirstName", "LastName", "ProviderName", "ProviderUserId", "Role" },
                values: new object[] { 2, "Warsaw", null, "Poland", "hrwebapplication.user@wp.pl", "Andrzej", "Powała", "AZURE_AD_B2C", "d9fa8c96-873b-481d-8194-78ff752f32d6", "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "CompanyId", "Country", "EmailAddress", "FirstName", "LastName", "ProviderName", "ProviderUserId", "Role" },
                values: new object[] { 3, "Warsaw", 1, "Poland", "hrwebapplication.hruser@wp.pl", "Jan", "Kowalski", "AZURE_AD_B2C", "0c198acb-ac45-47ac-9b49-46dc37c373b4", "HRUser" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Description", "Location", "Name" },
                values: new object[] { 2, "DES..", "Warsaw", "Apple" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "CompanyId", "Country", "EmailAddress", "FirstName", "LastName", "ProviderName", "ProviderUserId", "Role" },
                values: new object[] { 1002, "Warsaw", null, "Poland", "hrwebapplication.user@wp.pl", "Andrzej", "Powała", "AZURE_AD_B2C", "d9fa8c96-873b-481d-8194-78ff752f32d6", "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "CompanyId", "Country", "EmailAddress", "FirstName", "LastName", "ProviderName", "ProviderUserId", "Role" },
                values: new object[] { 1003, "Warsaw", 2, "Poland", "hrwebapplication.hruser@wp.pl", "Jan", "Kowalski", "AZURE_AD_B2C", "0c198acb-ac45-47ac-9b49-46dc37c373b4", "HRUser" });
        }
    }
}
