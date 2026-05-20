using Egygroup.BLL.DTOS;
using Egygroup.BLL.Services;
using Egygroup.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Egygroup.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly IProductService _productService;

        public HomeController(IBrandService brandService, IProductService productService)
        {
            _brandService = brandService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var vm = new HomeViewModel
            {
                Brands = _brandService.GetAll().ToList(),
                FeaturedProducts = _productService.GetAll()
                    .Where(p => p.IsActive)
                    .Take(6)
                    .ToList()
            };

            return View(vm);
        }
    }
}
