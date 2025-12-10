using DataAccessLayer.Repos;
using EntityLayer.Entities;
using EntityLayer.Interfaces;


namespace BusinessLogicLayer
{
    public class InvoiceService
    {
        private readonly IRepository<Invoice> _repo = new SqlServerInvoiceRepository();
            
        public Invoice CreateInvoice(Client client, List<(Product product, int qty)> lines, decimal tax)
        {
            var invoice = new Invoice
            {
                ClientId = client.Id
            };

            foreach (var (product, qty) in lines)
            {
                var line = new InvoiceLine
                {
                    Quantity = qty,
                    SalePrice = product.Price,
                    ProductId = product.Id,
                    InvoiceId = invoice.Id,
                };

                invoice.InvoiceLines.Add(line);
            }

            invoice.Subtotal = invoice.InvoiceLines.Sum(detalle => detalle.LineTotal);
            invoice.Taxes = invoice.Subtotal * tax;
            invoice.Total = invoice.Subtotal + invoice.Taxes;

            _repo.Add(invoice);
            return invoice;

        }

        public IEnumerable<Invoice> GetAllInvoices()
            => _repo.GetAll();

        public Invoice? GetInvoice(int id)
            => _repo.GetById(id);

        public void UpdateInvoice(Invoice invoice)
            => _repo.Update(invoice);

        public void DeleteInvoice(int id)
            => _repo.Delete(id);
    }
}
