using Microsoft.EntityFrameworkCore.Migrations;

namespace App2c2pTest.Data.Migrations
{
    public partial class CreditCard_ExiiryDate_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpiryDate",
                table: "CreditCards",
                maxLength: 6,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "CreditCards");
        }
    }
}
