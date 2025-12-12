using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Invoice : BaseEntity
    {
        public decimal Subtotal { get; set; }
        public decimal Taxes { get; set; }
        public decimal Total { get; set; }

        public int ClientId { get; set; }
        public Client? Client { get; set; }

        public ICollection<InvoiceLine> InvoiceLines { get; } = new List<InvoiceLine>();
    }
}
