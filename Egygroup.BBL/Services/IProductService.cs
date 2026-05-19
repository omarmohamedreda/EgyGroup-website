using Egygroup.BLL.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egygroup.BLL.Services
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAll();
        IEnumerable<ProductDto> GetByBrand(int brandId);
        ProductDto? GetById(int id);
        void Add(ProductDto dto);
        void Update(ProductDto dto);
        void Delete(int id);
    }
}
