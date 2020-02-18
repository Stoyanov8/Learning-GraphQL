using System.Collections.Generic;
using System.Linq;
using ASP.Core.GraphQL.Database.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ASP.Core.GraphQL.Database.Extensions
{
    public static class DatabaseBuilder
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app, bool seed)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ShopContext>();

                if(seed)
                    Seed(context);

                context.Database.Migrate();
             
            }   
            return app;
        }

        public static void Seed(ShopContext context)
        {
            context.Set<Product>().AddRange(GetProducts);
            context.Set<Category>().AddRange(GetCategories);

            context.SaveChanges();
        }

        private static IList<Category> GetCategories => new List<Category>()
        {
            new Category()
            {
                Name = "Tableware",
            },
            new Category()
            {
                Name = "Vehicle",

            },
            new Category()
            {
                Name = "Furniture",

            }
        };

        private static IList<Product> GetProducts => new List<Product>()
        {
            new Product
            {
                Available = false,
                Name = "Knife",
                Count = 0,
                CategoryId = 1,

            },
            new Product
            {
                Available = true,
                Name = "Honda Civic",
                Count = 216,
                CategoryId = 2,
            },
            new Product
            {
                Available = true,
                Name = "Very cool chair 101",
                Count = 2,
                CategoryId = 3
            }
        };
    }
}
