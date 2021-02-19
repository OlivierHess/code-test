using CodeTest.Domain.Areas.Products.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CodeTest.SqlDataAccess.Data
{
    public static class CodeTestContextInitialiser
    {
        public static void Initialise(CodeTestContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product { Name = "Lavender heart", Price = (decimal) 9.25 },
                    new Product { Name = "Personalised cufflinks", Price = (decimal) 45.00 },
                    new Product { Name = "Kids T-shirt", Price = (decimal) 19.95 }
                };

                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}