using CRUD_WEB_API.Models;
using CRUD_WEB_API.Paginations;
using CRUD_WEB_API.SearchingModels;
using CRUD_WEB_API.SortingModels;

namespace CRUD_WEB_API.Repositories
{
    public class MeetUpRepository : IDbRepository<MeetUp>
    {
        private readonly ApplicationDbContext _context;

        public MeetUpRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MeetUp> GetList()
        {
            return _context.MeetUps.ToList();
        }

        public MeetUp Get(int id)
        {
            return _context.MeetUps.Find(id);
        }

        public IEnumerable<MeetUp> GetWithOptions(Pagination pagination, SortingOptions sortingOptions, string subString)
        {
            return _context.MeetUps
                .Search(subString)
                .Sort(sortingOptions)
                .Paginate(pagination);
        }

        public void Create(MeetUp Item)
        {
            _context.MeetUps.Add(Item);
            _context.SaveChanges();
        }

        public void Update(MeetUp updatedItem)
        {
            var currentItem = Get(updatedItem.Id);
            currentItem.Title = updatedItem.Title;
            currentItem.Description = updatedItem.Description;
            currentItem.Tags = updatedItem.Tags;
            currentItem.Date = updatedItem.Date;
            currentItem.Location = updatedItem.Location;

            _context.MeetUps.Update(currentItem);
            _context.SaveChanges();
        }

        public MeetUp Delete(int id)
        {
            var meetUp = Get(id);
            if (meetUp != null)
            {
                _context.MeetUps.Remove(meetUp);
                _context.SaveChanges();
            }

            return meetUp;
        }
    }
}