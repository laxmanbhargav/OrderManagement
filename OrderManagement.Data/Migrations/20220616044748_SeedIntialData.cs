using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManagement.Data.Migrations
{
    public partial class SeedIntialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newsequentialid())"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    password = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newsequentialid())"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_Order",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "email", "name", "password" },
                values: new object[] { new Guid("01d89928-5385-4c4f-bbde-889b6afce928"), "johndoe@abccorp.com", "John Doe", "12345678" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "email", "name", "password" },
                values: new object[] { new Guid("8a153499-0dba-4e7f-af83-a2f08e284f8d"), "jimcarey@abccorp.com", "Jim Carey", "12345678" });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "id", "description", "name", "userId" },
                values: new object[] { new Guid("97d98542-1342-4f47-9921-a305bb5b65c0"), "This is my Second Order", "Order 2", new Guid("8a153499-0dba-4e7f-af83-a2f08e284f8d") });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "id", "description", "name", "userId" },
                values: new object[] { new Guid("bd673eb8-104f-4079-b0f3-b2c1d430b808"), "This is my first order", "Order 1", new Guid("01d89928-5385-4c4f-bbde-889b6afce928") });

            migrationBuilder.CreateIndex(
                name: "IX_Order_userId",
                table: "Order",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
