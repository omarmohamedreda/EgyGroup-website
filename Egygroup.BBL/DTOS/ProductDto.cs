using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egygroup.BLL.DTOS
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string NameEn { get; set; } = string.Empty;
        public string NameAr { get; set; } = string.Empty;
        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public int BrandId { get; set; }
        public string? BrandNameEn { get; set; }
        public string? BrandNameAr { get; set; }
    }
}
