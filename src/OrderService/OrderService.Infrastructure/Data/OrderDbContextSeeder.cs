using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Data
{
    public class OrderDbContextSeeder
    {
        public static async Task SeedAsync(OrderDbContext orderDbContext, 
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                orderDbContext.Database.Migrate();
                if(!orderDbContext.Orders.Any())
                {
                    orderDbContext.Orders.AddRange(GetPreConfiguredOrders());
                    await orderDbContext.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {

                if (retryForAvailability < 3)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<OrderDbContextSeeder>();
                    log.LogError(exception.Message);
                    await SeedAsync(orderDbContext, loggerFactory, retryForAvailability);
                }
            }

        }

        private static IEnumerable<Order> GetPreConfiguredOrders()
        {
            return new List<Order>
            {
                new Order() { 
                    UserName = "philz", 
                    FirstName = "Theo", 
                    LastName = "Ighalo",
                    EmailAddress= "philz@gmail.com",
                    AddressLine = "Sabo Yaba",
                    Country = "Nigeria"
                }
            };
        }
    }
}
