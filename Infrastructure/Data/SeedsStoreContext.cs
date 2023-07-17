using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using core.Enities;
using Microsoft.Extensions.Logging;



namespace Infrastructure.Data
{
    public class SeedsStoreContext
    {
   
        public static async Task SeedAsync(StoreContext context , ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var BrandsData = File.ReadAllText("C:/Users/Ahmed/Desktop/.net/skinet/Infrastructure/Data/SeedsData/brands.json");
                    var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);
                    
                    foreach (var item in Brands)
                    {
                        context.ProductBrands.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("C:/Users/Ahmed/Desktop/.net/skinet/Infrastructure/Data/SeedsData/types.json");
                    var Types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    
                    foreach (var item in Types)
                    {
                        context.ProductTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    var ProductssData = File.ReadAllText("C:/Users/Ahmed/Desktop/.net/skinet/Infrastructure/Data/SeedsData/products.json");
                    var Products = JsonSerializer.Deserialize<List<Product>>(ProductssData);
                    
                    foreach (var item in Products)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Hello, world!");         
            }
        }
    }
}