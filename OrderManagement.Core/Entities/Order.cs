using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OrderManagement.Core.Entities
{
    public partial class Order
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid UserId { get; set; }
        public string Description { get; set; } = null!;

        [JsonIgnore]
        public virtual User User { get; set; } = null!;
    }
}
