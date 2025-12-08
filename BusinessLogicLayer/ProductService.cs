using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repos;
using EntityLayer.Entities;
using EntityLayer.Interfaces;

namespace BusinessLogicLayer
{
    public class ProductService
    {
        private readonly IRepository<Product> _repo = new FakeProductRepository();


        public async Task<IEnumerable<Product>> GetAllProducts()
            => await _repo.GetAll();

        public async Task<Product?> GetProduct(int id)
            => await _repo.GetById(id);

        public async Task<Product> CreateProduct(string name, decimal price, int stock)
        {
            var product = new Product { Name = name, Price = price, Stock = stock };
            await _repo.Add(product);
            return product;
        }

        public async Task UpdateProduct(Product product)
            => await _repo.Update(product);

        public async Task DeleteProduct(int id)
            => await _repo.Delete(id);
    }
}
