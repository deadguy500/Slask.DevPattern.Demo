using AutoMapper;
using Slask.Data.Contract;
using Slask.Data.Contract.Entities;
using Slask.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Slask.Data.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly DbContext _dbContext;

        public UserRepository(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserEntity> GetAsync(Guid id)
        {
            var user = _dbContext.Users.FindById(id);
            return _mapper.Map<UserEntity>(user);
        }

        public async Task<List<UserEntity>> GetListAsync()
        {
            var users = _dbContext.Users.FindAll().ToList();
            return _mapper.Map<List<UserEntity>>(users);
        }

        public async Task AddAsync(UserEntity entity)
        {
            var user = _mapper.Map<DbUser>(entity);
            _dbContext.Users.Insert(user);
        }
    }
}
