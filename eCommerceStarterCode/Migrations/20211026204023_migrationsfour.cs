using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerceStarterCode.Migrations
{
    public partial class migrationsfour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c352887-ea84-4dcb-b6f5-252209b63ee7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d49f24bd-102f-4cbc-b6b4-38531c9ed86f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "81d9cec7-6a79-4e08-bea2-3721cc3370f5", "2cf97b78-140e-45be-b92c-3ccb5e46f9fe", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7b2e60ff-dd12-4a29-9e12-e6f2dd6988bc", "13cb160d-a9fb-4bb1-b1b1-4f8733c92130", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b2e60ff-dd12-4a29-9e12-e6f2dd6988bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81d9cec7-6a79-4e08-bea2-3721cc3370f5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d49f24bd-102f-4cbc-b6b4-38531c9ed86f", "4cdefc31-34c1-4854-8ed7-ec8e29978913", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c352887-ea84-4dcb-b6f5-252209b63ee7", "b219a861-1032-4731-a3fb-47a31c8ba8d8", "Admin", "ADMIN" });
        }
    }
}
