using System.ComponentModel.DataAnnotations;

namespace Egygroup.PL.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "English Name is required")]
        [MaxLength(200)]
        public string NameEn { get; set; } = string.Empty;

        [Required(ErrorMessage = "الاسم بالعربي مطلوب")]
        [MaxLength(200)]
        public string NameAr { get; set; } = string.Empty;

        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }

        public string? ImageUrl { get; set; }
        public IFormFile? ImageFile { get; set; }

        public bool IsActive { get; set; } = true;

        [Required(ErrorMessage = "Brand is required")]
        public int BrandId { get; set; }
    }
}