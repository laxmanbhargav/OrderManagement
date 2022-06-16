using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Core.Models
{
    public class LoginDto
    {
        public string email { get; set; } = null!;
        public string password { get; set; } = null!;
    }
}
