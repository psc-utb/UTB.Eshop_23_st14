using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Database;

namespace UTB.Eshop.Application.Implementation
{
    public class ProductAppService : IProductAppService
    {
        IFileUploadService _fileUploadService;
        EshopDbContext _eshopDbContext;

        public ProductAppService(IFileUploadService fileUploadService, EshopDbContext eshopDbContext)
        {
            _fileUploadService = fileUploadService;
            _eshopDbContext = eshopDbContext;
        }

        public IList<Product> Select()
        {
            return _eshopDbContext.Products.ToList();
        }

        public async Task Create(Product product)
        {
            string imageSrc = await _fileUploadService.FileUploadAsync(product.Image, Path.Combine("img", "products"));
            product.ImageSrc = imageSrc;

            if (_eshopDbContext.Products != null)
            {
                _eshopDbContext.Products.Add(product);
                _eshopDbContext.SaveChanges();
            }
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            Product? product
                = _eshopDbContext.Products.FirstOrDefault(prod => prod.Id == id);

            if (product != null)
            {
                _eshopDbContext.Products.Remove(product);
                _eshopDbContext.SaveChanges();
                deleted = true;
            }
            return deleted;
        }
    }
}
