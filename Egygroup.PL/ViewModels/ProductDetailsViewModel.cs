namespace Egygroup.PL.ViewModels
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string NameEn { get; set; } = string.Empty;
        public string NameAr { get; set; } = string.Empty;
        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public int BrandId { get; set; }
        public string? BrandNameEn { get; set; }
        public string? BrandNameAr { get; set; }
    }
}