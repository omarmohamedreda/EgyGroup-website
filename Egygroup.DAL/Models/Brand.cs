using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egygroup.DAL.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string NameEn { get; set; } = null!;
        public string NameAr { get; set; } = null!;
        public string? LogoUrl { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }

        // Navigation
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
