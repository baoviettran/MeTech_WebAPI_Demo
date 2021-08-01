using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ECommerce.Data.EF
{
    public class ECommerceDbContextFactory : IDesignTimeDbContextFactory<ECommerceDbContext>
    {
        public ECommerceDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ECommerceDbContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("ECommerceDb"));

            return new ECommerceDbContext(optionsBuilder.Options);
        }
    }
}