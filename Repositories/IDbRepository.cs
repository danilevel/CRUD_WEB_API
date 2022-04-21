using CRUD_WEB_API.Models;
using CRUD_WEB_API.Paginations;
using CRUD_WEB_API.SortingModels;

namespace CRUD_WEB_API.Repositories
{
    public interface IDbRepository<T> where T : class
    {
        IEnumerable<T> GetList();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        T Delete(int id);
        IEnumerable<MeetUp> GetWithOptions(Pagination pagination, SortingOptions sortingOptions, string subString);
    }
}