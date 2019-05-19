using Slask.Data.Contract;
using Slask.Domain.Contract;
using Slask.Domain.Contract.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Slask.Data.Contract.Entities;

namespace Slask.Domain.Implementation
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(id);

            return _mapper.Map<User>(user);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var users = await _userRepository.GetListAsync();

            return _mapper.Map<List<User>>(users);
        }

        public async Task AddUserAsync(User model)
        {
            var user = _mapper.Map<UserEntity>(model);

            await _userRepository.AddAsync(user);
        }
    }
}
