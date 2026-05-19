using Egygroup.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Egygroup.PL.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;

        public ProductsController(IProductService productService, IBrandService brandService)
        {
            _productService = productService;
            _brandService = brandService;
        }

        // GET: /products
        public IActionResult Index()
        {
            var products = _productService.GetAll();
            return View(products);
        }

        // GET: /products/brand/id
        public IActionResult ByBrand(int id)
        {
            var products = _productService.GetByBrand(id);
            var brand = _brandService.GetById(id);
            ViewBag.BrandNameEn = brand?.NameEn;
            ViewBag.BrandNameAr = brand?.NameAr;
            return View("Index", products);
        }

        // GET: /products/details/id
        public IActionResult Details(int id)
        {
            var product = _productService.GetById(id);
            if (product is null) return NotFound();
            return View(product);
        }
    }
}
