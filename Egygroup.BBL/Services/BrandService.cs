using Egygroup.BLL.DTOS;
using Egygroup.DAL.Models;
using Egygroup.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egygroup.BLL.Services
{
    public class BrandService: IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<BrandDto> GetAll()
        {
            return _unitOfWork.Brands.GetAll().Select(b => new BrandDto
            {
                Id = b.Id,
                NameEn = b.NameEn,
                NameAr = b.NameAr,
                LogoUrl = b.LogoUrl,
                DescriptionEn = b.DescriptionEn,
                DescriptionAr = b.DescriptionAr
            });
        }

        public BrandDto? GetById(int id)
        {
            var b = _unitOfWork.Brands.GetById(id);
            if (b is null) return null;

            return new BrandDto
            {
                Id = b.Id,
                NameEn = b.NameEn,
                NameAr = b.NameAr,
                LogoUrl = b.LogoUrl,
                DescriptionEn = b.DescriptionEn,
                DescriptionAr = b.DescriptionAr
            };
        }

        public void Add(BrandDto dto)
        {
            var brand = new Brand
            {
                NameEn = dto.NameEn,
                NameAr = dto.NameAr,
                LogoUrl = dto.LogoUrl,
                DescriptionEn = dto.DescriptionEn,
                DescriptionAr = dto.DescriptionAr
            };
            _unitOfWork.Brands.Add(brand);
            _unitOfWork.Complete();
        }

        public void Update(BrandDto dto)
        {
            var brand = _unitOfWork.Brands.GetById(dto.Id);
            if (brand is null) return;

            brand.NameEn = dto.NameEn;
            brand.NameAr = dto.NameAr;
            brand.LogoUrl = dto.LogoUrl;
            brand.DescriptionEn = dto.DescriptionEn;
            brand.DescriptionAr = dto.DescriptionAr;

            _unitOfWork.Brands.Update(brand);
            _unitOfWork.Complete();
        }

        public void Delete(int id)
        {
            var brand = _unitOfWork.Brands.GetById(id);
            if (brand is null) return;

            _unitOfWork.Brands.Delete(brand);
            _unitOfWork.Complete();
        }
    }
}
