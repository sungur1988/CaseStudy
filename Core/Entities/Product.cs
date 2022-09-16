using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public int Stock { get; set; }
        public virtual int BrandId { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
