using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Eshop.Domain.Entities;

namespace UTB.Eshop.Infrastructure.Database
{
    public class DatabaseFake
    {
        public static IList<Product> Products { get; set; }

        static DatabaseFake()
        {
            Products = new List<Product>();
            Products.Add(new Product { 
                Id = 1,
                Name = "iPhone",
                Description = "smartphone",
                Price = 15000,
                ImageSrc = ""
            });
            Products.Add(new Product
            {
                Id = 2,
                Name = "iPhone 2",
                Description = "smartphone",
                Price = 15000,
                ImageSrc = ""
            });
            Products.Add(new Product
            {
                Id = 3,
                Name = "iPhone 3",
                Description = "smartphone",
                Price = 15000,
                ImageSrc = ""
            });
        }
    }
}
