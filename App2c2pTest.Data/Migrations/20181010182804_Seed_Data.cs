using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App2c2pTest.Data.Migrations
{
    public partial class Seed_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CreditCards",
                columns: new[] { "Id", "Card", "CardDescription", "DateCreated", "ExpiryDate", "IsActive", "IsDeleted" },
                values: new object[,]
                {
                    { 1, "4909-2832-8723-8888", "Visa Card Sample", new DateTime(2018, 10, 10, 19, 28, 2, 930, DateTimeKind.Local), 81980, true, false },
                    { 2, "5909-2222-8723-8888", "Master Card Sample", new DateTime(2018, 10, 10, 19, 28, 2, 931, DateTimeKind.Local), 81933, true, false },
                    { 3, "3409-2222-8723-888", "Amex Card Sample", new DateTime(2018, 10, 10, 19, 28, 2, 931, DateTimeKind.Local), 81973, true, false },
                    { 4, "3528-3589-8723-8888", "JCB Card Sample", new DateTime(2018, 10, 10, 19, 28, 2, 931, DateTimeKind.Local), 81963, true, false },
                    { 5, "3709-2222-8723-8888", "Amex Card Sample", new DateTime(2018, 10, 10, 19, 28, 2, 931, DateTimeKind.Local), 81963, true, false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CreditCards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CreditCards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CreditCards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CreditCards",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CreditCards",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
