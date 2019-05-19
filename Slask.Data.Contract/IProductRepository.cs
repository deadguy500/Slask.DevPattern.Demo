using Slask.Data.Contract.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Slask.Data.Contract
{
    public interface IProductRepository
    {
        Task<List<ProductEntity>> GetList();
    }
}
