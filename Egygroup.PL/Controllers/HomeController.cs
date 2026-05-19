using Egygroup.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Egygroup.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBrandService _brandService;

        public HomeController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public IActionResult Index()
        {
            var brands = _brandService.GetAll();
            return View(brands);
        }
    }
}
