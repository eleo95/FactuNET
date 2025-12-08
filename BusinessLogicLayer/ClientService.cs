using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Entities;
using EntityLayer.Interfaces;
using DataAccessLayer.Repos;

namespace BusinessLogicLayer
{
    public class ClientService
    {
        private readonly IClientRepository _repo = new FakeClientRepository();


        public async Task<IEnumerable<Client>> GetAllClients()
            => await _repo.GetAll();

        public async Task<Client?> GetClient(int id)
            => await _repo.GetById(id);

        public async Task<Client> CreateClient(string name, string email, string rnc, string address)
        {
            var client = new Client { Name = name, Email = email, Rnc = rnc, Address = address};
            await _repo.Add(client);
            return client;
        }

        public async Task UpdateClient(Client client)
            => await _repo.Update(client);

        public async Task DeleteClient(int id)
            => await _repo.Delete(id);
    }
}
