using Dapper.Application.Interfaces;
using Dapper.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dapper.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task<int> AddAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
