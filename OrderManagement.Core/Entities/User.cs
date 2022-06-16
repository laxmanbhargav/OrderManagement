using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Core.Entities
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
