using Egygroup.DAL.Models;
using Egygroup.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egygroup.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Brand> Brands { get; }
        IGenericRepository<Product> Products { get; }
        int Complete();
    }
}
