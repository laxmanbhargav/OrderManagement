using OrderManagement.Core.Entities;
using OrderManagement.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OrderManagement.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly OrderManagementContext _orderManagementContext;
        public UserRepository(OrderManagementContext orderManagementContext)
        {
            _orderManagementContext = orderManagementContext;
        }
        public async Task<User> GetUser(string email, string password)
        {
            try
            {
               var userResponse = await _orderManagementContext.Users.FirstOrDefaultAsync(x => (x.Email.Equals(email) && x.Password.Equals(password)));
                return userResponse;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
