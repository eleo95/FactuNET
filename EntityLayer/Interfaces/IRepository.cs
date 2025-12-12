namespace EntityLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T? GetById(int id);
        IEnumerable<T> GetAll();
        T? Add(T obj);
        void Update(T obj);
        void Delete(int id);
    }
}
