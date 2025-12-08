using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Entities;
using EntityLayer.Interfaces;

namespace DataAccessLayer.Repos
{
    public class FakeInvoiceRepository : IInvoiceRepository
    {
        private readonly List<Invoice> _invoices = new();
        private int _nextId = 1;

        public Task Add(Invoice invoice)
        {
            invoice.Id = _nextId++;
            int idx = 0;
            foreach (var line in invoice.InvoiceLines)
            {
                line.Id = invoice.Id * 1000 + idx; // fake ID
                idx++;
            }
            _invoices.Add(invoice);
            
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Invoice>> GetAll()
            => Task.FromResult<IEnumerable<Invoice>>(_invoices);

        public Task<Invoice?> GetById(int id)
            => Task.FromResult(_invoices.FirstOrDefault(i => i.Id == id));

        public Task Update(Invoice invoice)
        {
            var existing = _invoices.FirstOrDefault(i => i.Id == invoice.Id);
            if (existing != null)
            {
                existing.Client = invoice.Client;
                existing.InvoiceLines = invoice.InvoiceLines;
                existing.Subtotal = invoice.Subtotal;
                existing.Taxes = invoice.Taxes;
                existing.Total = invoice.Total;
            }
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var invoice = _invoices.FirstOrDefault(i => i.Id == id);
            if (invoice != null) _invoices.Remove(invoice);
            return Task.CompletedTask;
        }
    }
}
