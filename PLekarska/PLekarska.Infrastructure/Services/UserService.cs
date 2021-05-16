using PLekarska.Core;
using PLekarska.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLekarska.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IReadOnlyList<User>> Get()
        {
            return await _userRepository.GetAsync();
        }

        public async Task<User> Get(Guid id)
        {
            return await _userRepository.GetAsync(id);
        }

        public async Task<int> Add(User user)
        {
            return await _userRepository.AddAsync(user);

        }
        public async Task<int> Delete(Guid id)
        {
            var user = await _userRepository.GetAsync(id);
            return await _userRepository.DeleteAsync(user);
        }
    }
}
