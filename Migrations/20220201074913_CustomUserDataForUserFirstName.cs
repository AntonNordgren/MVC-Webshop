using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Webshop.Migrations
{
    public partial class CustomUserDataForUserFirstName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ea69ee4-06ce-4f0c-a9a6-c71ecb9cfd07");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "351c7b38-39d3-4f93-9833-38dd705fe2b2", "1fbe65dc-5cfd-4d21-a313-8c4c537af79b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fbe65dc-5cfd-4d21-a313-8c4c537af79b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "351c7b38-39d3-4f93-9833-38dd705fe2b2");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "1fbe65dc-5cfd-4d21-a313-8c4c537af79b", "2038a001-7076-4f1a-9ab1-07e6ee9daf6f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0ea69ee4-06ce-4f0c-a9a6-c71ecb9cfd07", "eb76808f-9ca6-41e5-b17f-a371959f468e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalNumber", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "351c7b38-39d3-4f93-9833-38dd705fe2b2", 0, null, null, "2157f87e-0fd3-4033-89b8-c30bc3094552", null, "admin@bookstore.com", true, null, null, false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEKpM7fYdZqmF1l57eKs0uq9HruuZfZxLmfOVZAMoKTdWXKC31PUm5TDAk1jT0kG+sQ==", null, false, null, "667a1cbf-2701-4a96-bf45-98aa4e8d1fd6", false, "admin@bookstore.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "351c7b38-39d3-4f93-9833-38dd705fe2b2", "1fbe65dc-5cfd-4d21-a313-8c4c537af79b" });
        }
    }
}
