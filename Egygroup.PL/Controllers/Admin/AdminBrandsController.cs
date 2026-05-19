using Egygroup.BLL.DTOS;
using Egygroup.BLL.Services;
using Egygroup.PL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Egygroup.PL.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [Route("admin/brands")]
    public class AdminBrandsController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly IWebHostEnvironment _env;

        public AdminBrandsController(IBrandService brandService, IWebHostEnvironment env)
        {
            _brandService = brandService;
            _env = env;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var brands = _brandService.GetAll();
            return View(brands);
        }

        [HttpGet("create")]
        public IActionResult Create() => View(new BrandViewModel());

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BrandViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            _brandService.Add(new BrandDto
            {
                NameEn = vm.NameEn,
                NameAr = vm.NameAr,
                DescriptionEn = vm.DescriptionEn,
                DescriptionAr = vm.DescriptionAr,
                LogoUrl = UploadFile(vm.LogoFile, "brands") ?? vm.LogoUrl
            });

            TempData["Success"] = "Brand created successfully!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var brand = _brandService.GetById(id);
            if (brand is null) return NotFound();

            return View(new BrandViewModel
            {
                Id = brand.Id,
                NameEn = brand.NameEn,
                NameAr = brand.NameAr,
                DescriptionEn = brand.DescriptionEn,
                DescriptionAr = brand.DescriptionAr,
                LogoUrl = brand.LogoUrl
            });
        }

        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, BrandViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            _brandService.Update(new BrandDto
            {
                Id = id,
                NameEn = vm.NameEn,
                NameAr = vm.NameAr,
                DescriptionEn = vm.DescriptionEn,
                DescriptionAr = vm.DescriptionAr,
                LogoUrl = UploadFile(vm.LogoFile, "brands") ?? vm.LogoUrl
            });

            TempData["Success"] = "Brand updated successfully!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var brand = _brandService.GetById(id);
            if (brand is null) return NotFound();
            return View(brand);
        }

        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _brandService.Delete(id);
            TempData["Success"] = "Brand deleted successfully!";
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