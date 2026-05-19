using System.ComponentModel.DataAnnotations;

namespace Egygroup.PL.ViewModels
{
    public class BrandViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "English Name is required")]
        [MaxLength(100)]
        public string NameEn { get; set; } = string.Empty;

        [Required(ErrorMessage = "الاسم بالعربي مطلوب")]
        [MaxLength(100)]
        public string NameAr { get; set; } = string.Empty;

        public string? LogoUrl { get; set; }
        public IFormFile? LogoFile { get; set; }   

        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }
    }
}