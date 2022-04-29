using AutoMapper;
using CRUD_WEB_API.DTO;

namespace CRUD_WEB_API.Interfaces
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            var result = _context.Set<T>().FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                return null;
            }

            return result;
        }

        public async Task<int> Create(T item)
        {
            var result = await _context.Set<T>().AddAsync(item);
            await _context.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task<int> Update(T item)
        {
            var result = _context.Set<T>().Update(item);
            await _context.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task<T> Delete(int id)
        {
            var item = GetById(id);

            if (item != null)
            {
                var result = _context.Set<T>().Remove(item);
                await _context.SaveChangesAsync();

                return result.Entity;
            }

            return null;
        }

        public async Task<bool> SaveChangesAsync()
        {
            await _context.SaveChangesAsync();

            return true;
        }
    }
}