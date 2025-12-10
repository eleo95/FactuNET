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
        private readonly IRepository<Client> _repo = new SqlServerClientRepository();


        public IEnumerable<Client> GetAllClients()
            => _repo.GetAll();

        public Client? GetClient(int id)
            => _repo.GetById(id);

        public Client CreateClient(string name, string email, string rnc, string address)
        {
            var client = new Client { Name = name, Email = email, Rnc = rnc, Address = address};
            _repo.Add(client);
            return client;
        }

        public void UpdateClient(Client client)
            => _repo.Update(client);

        public void DeleteClient(int id)
            => _repo.Delete(id);
    }
}
