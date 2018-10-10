using System;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditCard>().HasData(new
                {
                    Id = 1,
                    Card = "4909-2832-8723-8888",
                    CardDescription = "Visa Card Sample",
                    ExpiryDate = 081980,
                    IsActive = true,
                    DateCreated = DateTime.Now,
                    IsDeleted = false
                },
                new
                {
                    Id = 2,
                    Card = "5909-2222-8723-8888",
                    CardDescription = "Master Card Sample",
                    ExpiryDate = 081933,
                    IsActive = true,
                    DateCreated = DateTime.Now,
                    IsDeleted = false
                },
                new
                {
                    Id = 3,
                    Card = "3409-2222-8723-888",
                    CardDescription = "Amex Card Sample",
                    ExpiryDate = 081973,
                    IsActive = true,
                    DateCreated = DateTime.Now,
                    IsDeleted = false
                },
                new
                {
                    Id = 4,
                    Card = "3528-3589-8723-8888",
                    CardDescription = "JCB Card Sample",
                    ExpiryDate = 081963,
                    IsActive = true,
                    DateCreated = DateTime.Now,
                    IsDeleted = false
                },
                  new
                {
                    Id = 5,
                    Card = "3709-2222-8723-8888",
                    CardDescription = "Amex Card Sample",
                    ExpiryDate = 081963,
                    IsActive = true,
                    DateCreated = DateTime.Now,
                    IsDeleted = false
                }

               

            );
           
            base.OnModelCreating(modelBuilder);
        }
    }
}
