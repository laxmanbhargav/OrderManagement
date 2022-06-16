using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Core.Entities;

namespace OrderManagement.Data.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUser(string email,string password);
    }
}
