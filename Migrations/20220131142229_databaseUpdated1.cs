using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Webshop.Migrations
{
    public partial class databaseUpdated1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d079f25-b0c0-4462-adca-349d63fd668e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "7939b130-2006-464e-bcbf-3a1d0139f79e", "b2f5ec06-1f6e-4f7a-8ce3-2cb5cd3f4146" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2f5ec06-1f6e-4f7a-8ce3-2cb5cd3f4146");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7939b130-2006-464e-bcbf-3a1d0139f79e");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "b2f5ec06-1f6e-4f7a-8ce3-2cb5cd3f4146", "a1d1d562-97a9-4795-a3fd-75dfd81f83c2", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2d079f25-b0c0-4462-adca-349d63fd668e", "4b613fea-f02e-4a9a-bf40-6427a0b17fd3", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalNumber", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7939b130-2006-464e-bcbf-3a1d0139f79e", 0, null, null, "36da0b5e-fac7-4c13-ac86-32f3cef75fa4", null, "admin@bookstore.com", true, null, null, false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEBziOQMILl9ZmJkpsLGlT4dSCwWxtIHrU5CSY7YCWofcxnB+Iu1CUNFPJxyUUGdc4A==", null, false, null, "469addcf-912d-45ba-a6b3-78a70b8a0b8c", false, "admin@bookstore.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "7939b130-2006-464e-bcbf-3a1d0139f79e", "b2f5ec06-1f6e-4f7a-8ce3-2cb5cd3f4146" });
        }
    }
}
