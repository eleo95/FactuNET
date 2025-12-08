using DataAccessLayer.Repos;
using EntityLayer.Entities;
using EntityLayer.Interfaces;


namespace BusinessLogicLayer
{
    public class InvoiceService
    {
        private readonly IInvoiceRepository _repo = new FakeInvoiceRepository();
            
        public async Task<Invoice> CreateInvoice(Client client, List<(Product product, int qty)> lines, decimal tax)
        {
            var invoice = new Invoice
            {
                Client = client
            };

            foreach (var (product, qty) in lines)
            {
                var line = new InvoiceLine
                {
                    Quantity = qty,
                    SalePrice = product.Price,
                    Product = product,
                    Invoice = invoice
                };

                invoice.InvoiceLines.Add(line);
            }

            invoice.Subtotal = invoice.InvoiceLines.Sum(detalle => detalle.LineTotal);
            invoice.Taxes = invoice.Subtotal * tax;
            invoice.Total = invoice.Subtotal + invoice.Taxes;

            await _repo.Add(invoice);
            return invoice;

        }

        public async Task<IEnumerable<Invoice>> GetAllInvoices()
            => await _repo.GetAll();

        public async Task<Invoice?> GetInvoice(int id)
            => await _repo.GetById(id);

        public async Task UpdateInvoice(Invoice invoice)
            => await _repo.Update(invoice);

        public async Task DeleteInvoice(int id)
            => await _repo.Delete(id);
    }
}
