using WebCRM.Models;

namespace WebCRM.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Sellers.Any())
                {
                    context.Sellers.AddRange(new List<Seller>()
                    {
                        new Seller()
                        {
                            Name = "Martin"
                        }
                    });
                }
                context.SaveChanges();

                if(!context.Customers.Any())
                {
                    context.Customers.AddRange(new List<Customer>()
                    {
                        new Customer()
                        {
                            Name = "Lika"
                        }
                    });
                }
                context.SaveChanges();
            }
        }
    }
}

