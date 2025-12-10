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
    public class SqlServerProductRepository : IRepository<Product>
    {

        public Product? Add(Product newProduct)
        {
            using (var context = new AppDbContext())
            {
                var entry = context.Products.Add(newProduct);
                 context.SaveChanges();

                return entry.Entity; // now has Id populated
            }
        }

        public void Delete(int id)
        {
            using (var context = new AppDbContext())
            { 
            var product = context.Products.Find(id);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
            }
        }

        public IEnumerable<Product> GetAll()
        {
            var lista = new List<Product>();
            using (var context = new AppDbContext())
            {
            lista = context.Products.ToList() ?? [];
            return lista;
            }
        }

        public Product? GetById(int id)
        {
            using (var context = new AppDbContext())
            {

            return  context.Products.Find(id);
            }
        }

        public void Update(Product obj)
        {
            using (var context = new AppDbContext())
            {
                context.Products.Update(obj);
                context.SaveChanges();
            }
            
        }

    }

}
