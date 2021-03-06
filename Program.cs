using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Theta.Context;
using Theta.Data;
using Theta.Helper;

namespace Theta
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            CreateDbIfNotExists(host);

            host.Run();
        }

        private static void CreateDbIfNotExists(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<RetailContext>();

            var exists = DatabaseHelper.CheckDatabaseExistsAndSeeded("Server=localhost,1433;Database=RetailDb;User Id=sa;Password=Password123;", "RetailDb");
            if (!exists) 
            {
                var customers = SampleCustomers.GetCustomers().ToList();
                context.Customer.AddRange(customers);
                context.SaveChanges();

                var products = SampleProducts.GetProducts().ToList();
                context.Product.AddRange(products);
                context.SaveChanges();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
