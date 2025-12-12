using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Entities;
using EntityLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repos
{
    public class SqlServerInvoiceRepository : IRepository<Invoice>
    {
        public Invoice? Add(Invoice invoice)
        {
            using(var context = new AppDbContext())
            {
                
                var data = context.Invoices.Add(invoice);
                
                context.SaveChanges();

                return data.Entity;
            }
        }

        public void Delete(int id)
        {
            using (var context = new AppDbContext())
            {
                var invoice = context.Invoices.Find(id);
                if (invoice != null)
                {
                    context.Invoices.Remove(invoice);
                    context.SaveChanges();
                }
            }
        }

        public IEnumerable<Invoice> GetAll()
        {

            using( var context = new AppDbContext())
            {
               return context.Invoices
                    .Include(c => c.Client)
                    .Include(l => l.InvoiceLines)
                    .AsSplitQuery()
                    .ToList();
            }
        }

        public Invoice? GetById(int id)
        {
            using ( var context = new AppDbContext())
            {
                return context.Invoices
                    .Where(i => i.Id == id)
                    .Include(c => c.Client)
                    .Include(l => l.InvoiceLines)
                    .AsSplitQuery()
                    .FirstOrDefault();
            }
        }

        public void Update(Invoice updatedInvoice)
        {
            using (var context = new AppDbContext())
            {
                context.Invoices.Update(updatedInvoice);
                context.SaveChanges();
            }
        }

        
    }
}
