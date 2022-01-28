using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Webshop.Migrations
{
    public partial class databaseupdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "4962f235-45b0-4bd2-b5be-35383d7412a4", "26177962-0645-4d78-9812-5c98e8ad6421", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "56b299dc-aad2-4632-94c3-63d194afc9f3", "572c63b6-c3c7-4ef2-ab4b-4b3bc8128511", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalNumber", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "517e783f-1226-4916-a311-91cfaa71e19d", 0, null, null, "f620ae7c-60e0-4a8a-b54a-4b7a069fb452", null, "admin@bookstore.com", true, null, null, false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEA0XLKYE1EmMhdjsF/SN7JqnxApBZ+EFq0s0Ukvxa0FFgBe6obalQwLAQPUU1+IO3g==", null, false, null, "4426e6fb-f1bc-42a5-a8e5-7a5b22036080", false, "admin@bookstore.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "517e783f-1226-4916-a311-91cfaa71e19d", "4962f235-45b0-4bd2-b5be-35383d7412a4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56b299dc-aad2-4632-94c3-63d194afc9f3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "517e783f-1226-4916-a311-91cfaa71e19d", "4962f235-45b0-4bd2-b5be-35383d7412a4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4962f235-45b0-4bd2-b5be-35383d7412a4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "517e783f-1226-4916-a311-91cfaa71e19d");

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
    }
}
