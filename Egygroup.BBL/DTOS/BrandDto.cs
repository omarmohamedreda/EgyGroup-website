using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egygroup.BLL.DTOS
{
    public class BrandDto
    {
        public int Id { get; set; }
        public string NameEn { get; set; } = string.Empty;
        public string NameAr { get; set; } = string.Empty;
        public string? LogoUrl { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }
    }
}
