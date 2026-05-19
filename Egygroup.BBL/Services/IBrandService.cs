using Egygroup.BLL.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egygroup.BLL.Services
{
    public interface IBrandService
    {
        IEnumerable<BrandDto> GetAll();
        BrandDto? GetById(int id);
        void Add(BrandDto dto);
        void Update(BrandDto dto);
        void Delete(int id);
    }
}
