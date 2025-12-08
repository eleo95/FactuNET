using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Entities;
using EntityLayer.Interfaces;

namespace DataAccessLayer.Repos
{
    public class FakeClientRepository : IClientRepository
    {
        private readonly List<Client> _clients = new();
        private int _nextId = 1;

        public Task<Client?> GetById(int id)
        {
            var client = _clients.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(client);
        }

        public Task<IEnumerable<Client>> GetAll()
        {
            return Task.FromResult<IEnumerable<Client>>(_clients);
        }

        public Task Add(Client client)
        {
            client.Id = _nextId++;
            _clients.Add(client);
            return Task.CompletedTask;
        }

        public Task Update(Client client)
        {
            var existing = _clients.FirstOrDefault(c => c.Id == client.Id);
            if (existing != null)
            {
                existing.Name = client.Name;
                existing.Email = client.Email;
                existing.Rnc = client.Rnc;
                existing.Address = client.Address;
            }
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var client = _clients.FirstOrDefault(c => c.Id == id);
            if (client != null)
                _clients.Remove(client);

            return Task.CompletedTask;
        }
    }

}
