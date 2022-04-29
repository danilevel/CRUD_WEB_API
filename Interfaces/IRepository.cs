using CRUD_WEB_API.DTO;

namespace CRUD_WEB_API.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        Task<int> Create(T item);
        Task<int> Update(T item);
        Task<T> Delete(int id);
        Task<bool> SaveChangesAsync();
    }
}