using Egygroup.BLL.DTOS;

namespace Egygroup.PL.ViewModels
{
    public class HomeViewModel
    {
        public List<BrandDto> Brands { get; set; } = new();
        public List<ProductDto> FeaturedProducts { get; set; } = new();
    }
}
