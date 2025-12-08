using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Entities;
using EntityLayer.Interfaces;

namespace DataAccessLayer.Repos
{
    public class FakeProductRepository : IRepository<Product>
    {
        private readonly List<Product> _products = new();
        private int _nextId = 1;
        public Task Add(Product product)
        {
            product.Id = _nextId++;
            _products.Add(product);
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var product = _products.FirstOrDefault(c => c.Id == id);
            if (product != null)
                _products.Remove(product);

            return Task.CompletedTask;
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            return Task.FromResult<IEnumerable<Product>>(_products);
        }

        public Task<Product?> GetById(int id)
        {
            var product = _products.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(product);
        }

        public Task Update(Product product)
        {
            var existing = _products.FirstOrDefault(c => c.Id == product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
                existing.Stock = product.Stock;
            }
            return Task.CompletedTask;
        }
    }
}
