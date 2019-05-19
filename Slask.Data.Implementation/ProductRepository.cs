using AutoMapper;
using Slask.Data.Contract;
using Slask.Data.Contract.Entities;
using Slask.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Slask.Data.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMapper _mapper;
        private readonly DbContext _dbContext;

        public ProductRepository(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<ProductEntity>> GetList()
        {
            var products = _dbContext.Products.FindAll().ToList();
            return _mapper.Map<List<ProductEntity>>(products);
        }
    }
}
