using CRUD_WEB_API.Models;
using CRUD_WEB_API.Options;

namespace CRUD_WEB_API.Services
{
    public interface IMeetUpService
    {
        IEnumerable<MeetUp> GetWithOptions(Pagination pagination,
                                           SortingOptions sortingOptions,
                                           string subString);
    }
}