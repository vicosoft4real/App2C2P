using Microsoft.EntityFrameworkCore.Migrations;

namespace App2c2pTest.Data.Migrations
{
    public partial class GetCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp = @"CREATE PROCEDURE GetCard
	                            @card nvarchar(19)
                    AS
                    BEGIN
	                -- SET NOCOUNT ON added to prevent extra result sets from
	                -- interfering with SELECT statements.
	                SET NOCOUNT ON;
                    -- select statements for card
	                SELECT TOP(1) * FROM CreditCards WHERE Card=@card
                    END
                    GO";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE dbo.GetCard ");
        }
    }
}
