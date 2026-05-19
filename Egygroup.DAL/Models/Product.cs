using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egygroup.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string NameEn { get; set; } = null!;
        public string NameAr { get; set; } = null!;
        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; } = true;

        // FK
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;
    }
}
