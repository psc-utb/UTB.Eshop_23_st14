using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Eshop.Domain.Entities;

namespace UTB.Eshop.Infrastructure.Database
{
    internal class DatabaseInit
    {
        public IList<Product> GetProducts()
        {
            IList<Product> products = new List<Product>();

            products.Add(new Product
            {
                Id = 1,
                Name = "Rohlík",
                Description = "nejlepší rohlík na světě",
                Price = 2,
                ImageSrc = "/img/products/produkty-01.jpg"
            });
            products.Add(new Product
            {
                Id = 2,
                Name = "Chleba",
                Description = "nejlepší chleba v galaxii",
                Price = 50,
                ImageSrc = "/img/products/produkty-02.jpg"
            });
            products.Add(new Product
            {
                Id = 3,
                Name = "Bageta",
                Description = "nejlepší bageta ve vesmíru",
                Price = 40,
                ImageSrc = "/img/products/produkty-05.jpg"
            });

            return products;
        }

        public IList<Carousel> GetCarousels()
        {
            IList<Carousel> carousels = new List<Carousel>();

            carousels.Add(new Carousel()
            {
                Id = 1,
                ImageSrc = "/img/carousel/information-technology-specialist.jpg",
                ImageAlt = "First slide"
            });

            carousels.Add(new Carousel()
            {
                Id = 2,
                ImageSrc = "/img/carousel/Information-Technology-1-1.jpg",
                ImageAlt = "Second slide"
            });

            carousels.Add(new Carousel()
            {
                Id = 3,
                ImageSrc = "/img/carousel/itec-index-banner.jpg",
                ImageAlt = "Third slide"
            });

            return carousels;
        }
    }
}
