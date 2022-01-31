using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Webshop.Migrations
{
    public partial class RelationshipBetweenUserAndOrderAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Order",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Order_ApplicationUserId",
                table: "Order",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_ApplicationUserId",
                table: "Order",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_ApplicationUserId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ApplicationUserId",
                table: "Order");

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

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Order");

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
    }
}
