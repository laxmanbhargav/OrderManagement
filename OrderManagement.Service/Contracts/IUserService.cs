using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Core.Models;



namespace OrderManagement.Service.Contracts
{
    public interface IUserService
    {
        Task<UserDto> GetUser(LoginDto login);


    }
}
