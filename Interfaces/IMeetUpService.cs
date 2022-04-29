using CRUD_WEB_API.DTO;
using CRUD_WEB_API.Options;

namespace CRUD_WEB_API.Interfaces
{
    public interface IMeetUpService
    {
        IEnumerable<MeetUp> GetWithOptions(Pagination pagination,
                                           SortingOptions sortingOptions,
                                           string subString);
    }
}