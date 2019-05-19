using Slask.Domain.Contract.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Slask.Domain.Contract
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
    }
}
