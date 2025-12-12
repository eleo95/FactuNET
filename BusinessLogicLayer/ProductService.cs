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
        private readonly IRepository<Product> _repo = new SqlServerProductRepository();


        public  IEnumerable<Product> GetAllProducts()
        {
            var results =  _repo.GetAll();
            return results;
        }

        public  Product? GetProduct(int id)
            =>  _repo.GetById(id);

        public  Product CreateProduct(string name, decimal price, int stock)
        {
            var product = new Product { Name = name, Price = price, Stock = stock };
             _repo.Add(product);
            return product;
        }

        public void UpdateProduct(Product product)
            =>  _repo.Update(product);

        public void DeleteProduct(int id)
            =>  _repo.Delete(id);
    }
}
