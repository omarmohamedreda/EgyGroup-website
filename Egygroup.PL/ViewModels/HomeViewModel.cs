using Egygroup.BLL.DTOS;

namespace Egygroup.PL.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<BrandDto> Brands { get; set; } = new List<BrandDto>();
        public IEnumerable<ProductDto> FeaturedProducts { get; set; } = new List<ProductDto>();
    }
}