using System;
using Slask.Data.Contract.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Slask.Data.Contract
{
    public interface IUserRepository
    {
        Task<UserEntity> GetAsync(Guid id);

        Task<List<UserEntity>> GetListAsync();

        Task AddAsync(UserEntity entity);
    }
}
