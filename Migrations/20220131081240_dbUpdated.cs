using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Webshop.Migrations
{
    public partial class dbUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2756218-3685-4dc1-8437-8a479c3f766a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "38ae24a2-f8e0-43e3-a2be-bd780345f2c9", "da7a3e3b-228b-449f-b0db-f9ae53290c89" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da7a3e3b-228b-449f-b0db-f9ae53290c89");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ae24a2-f8e0-43e3-a2be-bd780345f2c9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "49c5d0e5-781a-4b5a-b1a8-28eac7a3f52e", "b2fc30dc-3e31-474c-8cae-72766e0a6969", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "502fd418-ee78-4a29-a05a-8c35b3201349", "cfa1990f-98bc-4bda-8447-870d97590883", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalNumber", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b3cbc980-82f1-4866-a185-0f0175961e08", 0, null, null, "74897bce-4901-47e8-9e78-6ee8e4121f43", null, "admin@bookstore.com", true, null, null, false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEOSR4ir1E3/aj6X0tdMbQauF/fHwAupQrY6B6ZDF/h+8/JpEypHzLGpCzbUj5BWUAg==", null, false, null, "d77ea623-09a8-4c50-9b0b-6a5a2dbbf6ca", false, "admin@bookstore.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "b3cbc980-82f1-4866-a185-0f0175961e08", "49c5d0e5-781a-4b5a-b1a8-28eac7a3f52e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "502fd418-ee78-4a29-a05a-8c35b3201349");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "b3cbc980-82f1-4866-a185-0f0175961e08", "49c5d0e5-781a-4b5a-b1a8-28eac7a3f52e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49c5d0e5-781a-4b5a-b1a8-28eac7a3f52e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b3cbc980-82f1-4866-a185-0f0175961e08");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "da7a3e3b-228b-449f-b0db-f9ae53290c89", "3a65674f-0504-4140-b1f6-e71b4f9e82f6", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c2756218-3685-4dc1-8437-8a479c3f766a", "aa391d34-557e-431d-b2f9-19b8edf3af9f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalNumber", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "38ae24a2-f8e0-43e3-a2be-bd780345f2c9", 0, null, null, "5f27eeb5-d70c-43c5-b8a6-3a2ef27ed466", null, "admin@bookstore.com", true, null, null, false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEFI9OnRVvXJERDQge/9yPuD6+mqxQSTrO+f38Y9KermsUxGZ1HOFQFMcdSPatjPnKA==", null, false, null, "4ca8166c-40f7-42de-be5a-f09ff23b33e5", false, "admin@bookstore.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "38ae24a2-f8e0-43e3-a2be-bd780345f2c9", "da7a3e3b-228b-449f-b0db-f9ae53290c89" });
        }
    }
}
