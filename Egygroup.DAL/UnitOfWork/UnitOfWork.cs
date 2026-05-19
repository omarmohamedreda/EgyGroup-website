using Egygroup.DAL.Contexts;
using Egygroup.DAL.Models;
using Egygroup.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egygroup.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IGenericRepository<Brand> Brands { get; private set; }
        public IGenericRepository<Product> Products { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Brands = new GenericRepository<Brand>(_context);
            Products = new GenericRepository<Product>(_context);
        }

        public int Complete() => _context.SaveChanges();
    }
}
