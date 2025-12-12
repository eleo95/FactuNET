using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; } = 0;

        public int Stock { get; set; } = 0;

    }
}
