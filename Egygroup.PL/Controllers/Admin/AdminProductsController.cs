using Egygroup.BLL.DTOS;
using Egygroup.BLL.Services;
using Egygroup.PL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Egygroup.PL.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [Route("admin/products")]
    public class AdminProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        private readonly IWebHostEnvironment _env;

        public AdminProductsController(
            IProductService productService,
            IBrandService brandService,
            IWebHostEnvironment env)
        {
            _productService = productService;
            _brandService = brandService;
            _env = env;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var products = _productService.GetAll();
            return View(products);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            ViewBag.Brands = _brandService.GetAll();
            return View(new ProductViewModel());
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Brands = _brandService.GetAll();
                return View(vm);
            }

            _productService.Add(new ProductDto
            {
                NameEn = vm.NameEn,
                NameAr = vm.NameAr,
                DescriptionEn = vm.DescriptionEn,
                DescriptionAr = vm.DescriptionAr,
                IsActive = vm.IsActive,
                BrandId = vm.BrandId,
                ImageUrl = UploadFile(vm.ImageFile, "products") ?? vm.ImageUrl
            });

            TempData["Success"] = "Product created successfully!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var product = _productService.GetById(id);
            if (product is null) return NotFound();

            ViewBag.Brands = _brandService.GetAll();
            return View(new ProductViewModel
            {
                Id = product.Id,
                NameEn = product.NameEn,
                NameAr = product.NameAr,
                DescriptionEn = product.DescriptionEn,
                DescriptionAr = product.DescriptionAr,
                IsActive = product.IsActive,
                BrandId = product.BrandId,
                ImageUrl = product.ImageUrl
            });
        }

        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProductViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Brands = _brandService.GetAll();
                return View(vm);
            }

            _productService.Update(new ProductDto
            {
                Id = id,
                NameEn = vm.NameEn,
                NameAr = vm.NameAr,
                DescriptionEn = vm.DescriptionEn,
                DescriptionAr = vm.DescriptionAr,
                IsActive = vm.IsActive,
                BrandId = vm.BrandId,
                ImageUrl = UploadFile(vm.ImageFile, "products") ?? vm.ImageUrl
            });

            TempData["Success"] = "Product updated successfully!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetById(id);
            if (product is null) return NotFound();
            return View(product);
        }

        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _productService.Delete(id);
            TempData["Success"] = "Product deleted successfully!";
            return RedirectToAction(nameof(Index));
        }

        private string? UploadFile(IFormFile? file, string folder)
        {
            if (file == null || file.Length == 0) return null;

            var path = Path.Combine(_env.WebRootPath, "uploads", folder);
            Directory.CreateDirectory(path);

            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            using var stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
            file.CopyTo(stream);

            return $"/uploads/{folder}/{fileName}";
        }
    }
}