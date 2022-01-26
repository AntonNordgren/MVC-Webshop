using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Webshop.Migrations
{
    public partial class SeededAdminRoleAndAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b6924d81-bde7-4f38-a5bd-9765a3960f1e", "aae8beb9-d112-4f72-b000-3e8d3daf11e7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalNumber", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "71c4f510-12e3-4c67-b7ff-fd3121b55d4b", 0, null, null, "9ec40488-67ba-47f7-a425-30657bd633f7", null, "admin@bookstore.com", false, null, null, false, null, "ADMIN@BOOKSTORE.COM", "ADMIN", "AQAAAAEAACcQAAAAEKnNDeZhw+DQFCVKro3cDFGTeJsgBrAp6wQbuuYxrxpHI/orLipoJa1Ys/dMsoVgxg==", null, false, null, "15558e04-138d-4439-ba03-b981d3c5607c", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "71c4f510-12e3-4c67-b7ff-fd3121b55d4b", "b6924d81-bde7-4f38-a5bd-9765a3960f1e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "71c4f510-12e3-4c67-b7ff-fd3121b55d4b", "b6924d81-bde7-4f38-a5bd-9765a3960f1e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6924d81-bde7-4f38-a5bd-9765a3960f1e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71c4f510-12e3-4c67-b7ff-fd3121b55d4b");
        }
    }
}
