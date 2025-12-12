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
    public class SqlServerClientRepository : IRepository<Client>
    {
        public Client Add(Client client)
        {
            using (var context = new AppDbContext())
            {
                
                var data = context.Clients.Add(client);
                context.SaveChanges();

                //newProduct.Id = data.Entity.Id;

                return data.Entity;

            }
        }

        public void Delete(int id)
        {
            using (var context = new AppDbContext())
            {
            var client = context.Clients.Find(id);
            if (client != null)
            {
                context.Clients.Remove(client);
                context.SaveChanges();
            }

            }
        }

        public IEnumerable<Client> GetAll()
        {
            var allClients = new List<Client>();
            using (var context = new AppDbContext())
            {
            allClients =  context.Clients.ToList() ?? [];
            }
            return allClients;
        }

        public Client? GetById(int id)
        {
           using(var context = new AppDbContext())
            {
                return context.Clients.Find(id);
            }
        }

        public void Update(Client client)
        {
            using(var context = new AppDbContext())
            {
                context.Clients.Update(client);
                context.SaveChanges();
            }
        }
    }
}
