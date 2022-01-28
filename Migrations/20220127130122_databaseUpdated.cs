using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Webshop.Migrations
{
    public partial class databaseUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b94bca5c-d895-4b99-b3be-6ae1fe4c88b9");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "a68d21e7-9ec3-4f5b-93c7-27d522c75a01", "6ce14f62-d27d-4736-bd9b-bdfdaee1ddd3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ce14f62-d27d-4736-bd9b-bdfdaee1ddd3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a68d21e7-9ec3-4f5b-93c7-27d522c75a01");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "41ecac81-9ec5-4132-be37-23a8b9ef018f", "16f71ba2-c8ab-425b-a577-9109e0d5a1cc", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ff429aec-cb8d-4218-bd5d-19414c79dab6", "6eb7bb01-93f5-4b9a-9808-95d70aa39707", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalNumber", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1a04a51e-e9c2-4297-86f4-f160359939a2", 0, null, null, "b5f3b3b0-714f-434c-a26c-ced14490cf05", null, "admin@bookstore.com", false, null, null, false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEF1ugeh/iOxBrQ8A1xcC5nRGebNouSzo3+0YdD/5uebGU0OSwLXlP+nzuVME3EbHug==", null, false, null, "258001ef-c9b3-4b34-9ea2-9cd9aaf416ef", false, "admin@bookstore.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "1a04a51e-e9c2-4297-86f4-f160359939a2", "41ecac81-9ec5-4132-be37-23a8b9ef018f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff429aec-cb8d-4218-bd5d-19414c79dab6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1a04a51e-e9c2-4297-86f4-f160359939a2", "41ecac81-9ec5-4132-be37-23a8b9ef018f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41ecac81-9ec5-4132-be37-23a8b9ef018f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a04a51e-e9c2-4297-86f4-f160359939a2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6ce14f62-d27d-4736-bd9b-bdfdaee1ddd3", "b227ea00-1066-4e0b-b837-07e011a39a40", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b94bca5c-d895-4b99-b3be-6ae1fe4c88b9", "e2cbf730-00f6-4e57-875d-badb4ba8e255", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalNumber", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a68d21e7-9ec3-4f5b-93c7-27d522c75a01", 0, null, null, "294b80d8-b596-45cd-811c-144c1bc90a1b", null, "admin@bookstore.com", false, null, null, false, null, "ADMIN@BOOKSTORE.COM", "ADMIN", "AQAAAAEAACcQAAAAEDW6EVq3GHCQuzs74Oz9ElDHlQqLVrxg5P5iUnH9pXjbRKHFWEh5wyp6cJvH5g5c5w==", null, false, null, "bf88a533-1d00-47c3-81db-a9c0a690487d", false, "admin@bookstore.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "a68d21e7-9ec3-4f5b-93c7-27d522c75a01", "6ce14f62-d27d-4736-bd9b-bdfdaee1ddd3" });
        }
    }
}
