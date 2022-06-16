using OrderManagement.Core.Models;
using OrderManagement.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using OrderManagement.Data.Repository;

namespace OrderManagement.Service.Facades
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDto> GetUser(LoginDto login)
        {
            var userResponse = await _userRepository.GetUser(login.email, login.password);
            var user = userResponse.Adapt<UserDto>();
            return user;
        }
    }
}
