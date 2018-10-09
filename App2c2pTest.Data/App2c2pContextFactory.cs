using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace App2c2pTest.Data
{
    public class App2c2pContextFactory : IDesignTimeDbContextFactory<App2c2pContext>
    {
        public App2c2pContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<App2c2pContext>();
                     optionsBuilder.UseSqlServer("Server=L-TAKINOLA2\\MSSQLSERVER2012; Database=App2c2pDb;User ID=sa;Password=qwerty;MultipleActiveResultSets=true;");
            return new App2c2pContext(optionsBuilder.Options);
        }
    }
}
