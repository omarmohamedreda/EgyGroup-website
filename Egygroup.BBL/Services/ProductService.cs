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
    public class ProductService: IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return _unitOfWork.Products.GetAll().Select(MapToDto);
        }

        public IEnumerable<ProductDto> GetByBrand(int brandId)
        {
            return _unitOfWork.Products.GetAll()
                .Where(p => p.BrandId == brandId)
                .Select(MapToDto);
        }

        public ProductDto? GetById(int id)
        {
            var p = _unitOfWork.Products.GetById(id);
            return p is null ? null : MapToDto(p);
        }

        public void Add(ProductDto dto)
        {
            var product = new Product
            {
                NameEn = dto.NameEn,
                NameAr = dto.NameAr,
                DescriptionEn = dto.DescriptionEn,
                DescriptionAr = dto.DescriptionAr,
                ImageUrl = dto.ImageUrl,
                IsActive = dto.IsActive,
                BrandId = dto.BrandId
            };
            _unitOfWork.Products.Add(product);
            _unitOfWork.Complete();
        }

        public void Update(ProductDto dto)
        {
            var product = _unitOfWork.Products.GetById(dto.Id);
            if (product is null) return;

            product.NameEn = dto.NameEn;
            product.NameAr = dto.NameAr;
            product.DescriptionEn = dto.DescriptionEn;
            product.DescriptionAr = dto.DescriptionAr;
            product.ImageUrl = dto.ImageUrl;
            product.IsActive = dto.IsActive;
            product.BrandId = dto.BrandId;

            _unitOfWork.Products.Update(product);
            _unitOfWork.Complete();
        }

        public void Delete(int id)
        {
            var product = _unitOfWork.Products.GetById(id);
            if (product is null) return;

            _unitOfWork.Products.Delete(product);
            _unitOfWork.Complete();
        }

        // ── Helper ──────────────────────────────────────────
        private static ProductDto MapToDto(Product p) => new ProductDto
        {
            Id = p.Id,
            NameEn = p.NameEn,
            NameAr = p.NameAr,
            DescriptionEn = p.DescriptionEn,
            DescriptionAr = p.DescriptionAr,
            ImageUrl = p.ImageUrl,
            IsActive = p.IsActive,
            BrandId = p.BrandId,
            BrandNameEn = p.Brand?.NameEn,
            BrandNameAr = p.Brand?.NameAr
        };
    }
}
