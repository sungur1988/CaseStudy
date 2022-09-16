using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Order : BaseEntity
    {
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
