using Slask.Domain.Contract.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Slask.Domain.Contract
{
    public interface IUserService
    {
        Task<User> GetUserAsync(Guid id);

        Task<List<User>> GetUsersAsync();

        Task AddUserAsync(User model);
    }
}
