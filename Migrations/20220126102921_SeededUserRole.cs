using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Webshop.Migrations
{
    public partial class SeededUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7143a49e-a45d-47b0-afab-90df8a01906a", "f248e830-c305-4169-8e74-da42d59e1a4a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bf4d7528-ae7f-41ce-acf6-a994130533e9", "97d1b66d-4abf-4bc9-96d9-a00773dea83b", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalNumber", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "216e6d2e-06ec-48a2-a9cd-9f761cf280f9", 0, null, null, "b7826d61-aab0-4700-a588-9cca8a87cda1", null, "admin@bookstore.com", false, null, null, false, null, "ADMIN@BOOKSTORE.COM", "ADMIN", "AQAAAAEAACcQAAAAEI7Yg4koNQ6tw2NsrDtSA3H0/wZ6KBXNmPzbdDnKZN5tKGS0R50C0gdzBDdTctyZ8Q==", null, false, null, "7ef11d48-91cb-4e02-b800-48a94e972d70", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "216e6d2e-06ec-48a2-a9cd-9f761cf280f9", "7143a49e-a45d-47b0-afab-90df8a01906a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf4d7528-ae7f-41ce-acf6-a994130533e9");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "216e6d2e-06ec-48a2-a9cd-9f761cf280f9", "7143a49e-a45d-47b0-afab-90df8a01906a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7143a49e-a45d-47b0-afab-90df8a01906a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "216e6d2e-06ec-48a2-a9cd-9f761cf280f9");

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
    }
}
