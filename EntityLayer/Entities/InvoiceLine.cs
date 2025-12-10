using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class InvoiceLine : BaseEntity
    {

        public int Quantity { get; set; }
        public decimal SalePrice { get; set; }
        public decimal LineTotal => Quantity * SalePrice;

        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public Invoice? Invoice { get; set; }
        public Product? Product { get; set; }
    }
}
