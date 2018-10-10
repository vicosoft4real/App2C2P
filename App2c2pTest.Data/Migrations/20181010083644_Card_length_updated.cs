using Microsoft.EntityFrameworkCore.Migrations;

namespace App2c2pTest.Data.Migrations
{
    public partial class Card_length_updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Card",
                table: "CreditCards",
                maxLength: 19,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 16,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Card",
                table: "CreditCards",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 19);
        }
    }
}
