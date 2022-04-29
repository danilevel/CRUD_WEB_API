using CRUD_WEB_API.Models;
using CRUD_WEB_API.Options;

namespace CRUD_WEB_API.Services
{
    public class MeetUpService : IMeetUpService
    {
        private readonly IRepository<MeetUp> _meetUpRepository;

        public MeetUpService(IRepository<MeetUp> meetUpRepository)
        {
            _meetUpRepository = meetUpRepository;
        }

        public IEnumerable<MeetUp> GetWithOptions(Pagination pagination,
                                                  SortingOptions sortingOptions,
                                                  string subString)
        {
            return _meetUpRepository.GetAll().Search(subString)
                                             .Sort(sortingOptions)
                                             .Paginate(pagination);
        }
    }
}