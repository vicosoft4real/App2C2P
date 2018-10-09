using App2c2pTest.Data.Entites;
using Microsoft.EntityFrameworkCore;


namespace App2c2pTest.Data
{
    public class App2c2pContext: DbContext
    {
        public App2c2pContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<CreditCard> CreditCards { get; set; }
    }
}
