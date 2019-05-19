using Slask.Data.Contract;
using Slask.Domain.Contract;
using Slask.Domain.Contract.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace Slask.Domain.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var products = await _productRepository.GetList();

            return _mapper.Map<List<Product>>(products);
        }
    }
}
