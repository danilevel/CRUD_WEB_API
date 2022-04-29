using CRUD_WEB_API.Models;

namespace CRUD_WEB_API.Services
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