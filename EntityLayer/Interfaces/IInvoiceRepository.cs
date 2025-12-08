
using EntityLayer.Entities;

namespace EntityLayer.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<Invoice?> GetById(int id);
        Task<IEnumerable<Invoice>> GetAll();
        Task Add(Invoice invoice);
        Task Update(Invoice invoice);
        Task Delete(int id);
    }
}
