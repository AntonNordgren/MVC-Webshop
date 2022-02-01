using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Webshop.Migrations
{
    public partial class CustomUserDataForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54b45e21-8525-436a-a76c-fd30a18ced33");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "91b12048-798b-42cd-9f89-39183b98756b", "ae09e4c3-58f7-47d1-841f-894b4c76178e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae09e4c3-58f7-47d1-841f-894b4c76178e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "91b12048-798b-42cd-9f89-39183b98756b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "544e9d42-9c62-4503-b360-3e73abda19f6", "3047de72-2215-45f5-948c-f7838553a622", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "24f023cd-15a8-479b-98a9-d454d1ec4340", "fe083fed-4d88-47af-9709-225c49bf8633", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalNumber", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1b0c1688-005c-4d3f-a464-4f5556d2362e", 0, null, null, "ad7aa78c-d7d7-4c64-8544-d6ee49fb74f6", null, "admin@bookstore.com", true, null, null, false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEKeW7B05dZ0G44sgVI5bPnpQ9pCUd3cPlrm7h+bPAYMm+yJNxwA1qIOlefnfk5biqw==", null, false, null, "bd956010-9406-4c58-bd56-bfe163ab7450", false, "admin@bookstore.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "1b0c1688-005c-4d3f-a464-4f5556d2362e", "544e9d42-9c62-4503-b360-3e73abda19f6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24f023cd-15a8-479b-98a9-d454d1ec4340");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1b0c1688-005c-4d3f-a464-4f5556d2362e", "544e9d42-9c62-4503-b360-3e73abda19f6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "544e9d42-9c62-4503-b360-3e73abda19f6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b0c1688-005c-4d3f-a464-4f5556d2362e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae09e4c3-58f7-47d1-841f-894b4c76178e", "bb794825-4586-4f3a-a5e7-d2d320d27b24", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "54b45e21-8525-436a-a76c-fd30a18ced33", "50fac679-592b-4f72-ade7-ff849bc9c68f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalNumber", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "91b12048-798b-42cd-9f89-39183b98756b", 0, null, null, "964776ae-c686-4667-ac91-b53742d1cbc7", null, "admin@bookstore.com", true, null, null, false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEN8ik30dSAfM3F8fSKVEKwUd+tjd+fHoIeGMiEMlMIdzbvu2uN3Tb50XLMtDBeE2SA==", null, false, null, "c2102da8-2082-47eb-b46a-7cc28f825377", false, "admin@bookstore.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "91b12048-798b-42cd-9f89-39183b98756b", "ae09e4c3-58f7-47d1-841f-894b4c76178e" });
        }
    }
}
