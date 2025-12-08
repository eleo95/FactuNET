using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Entities;

namespace EntityLayer.Interfaces
{
    public interface IClientRepository
    {
        Task<Client?> GetById(int id);
        Task<IEnumerable<Client>> GetAll();
        Task Add(Client client);
        Task Update(Client client);
        Task Delete(int id);
    }
}
