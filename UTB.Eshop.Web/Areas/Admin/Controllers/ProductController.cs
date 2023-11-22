using Microsoft.AspNetCore.Mvc;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Database;

namespace UTB.Eshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        IProductAppService _productAppService;
        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public IActionResult Index()
        {
            IList<Product> products = _productAppService.Select();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productAppService.Create(product);

                return RedirectToAction(nameof(ProductController.Index));
            }
            else
            {
                return View(product);
            }
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _productAppService.Delete(id);

            if (deleted)
            {
                return RedirectToAction(nameof(ProductController.Index));
            }
            else
                return NotFound();
        }
    }
}
