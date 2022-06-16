using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Core.Models
{
    public class OrderDto
    {
        public string? Id { get; set; }
        public string Name { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
