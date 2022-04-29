using CRUD_WEB_API.Models;

namespace CRUD_WEB_API.Options
{
    public static class SortingMeetUp
    {
        public static IEnumerable<MeetUp> Sort(this IEnumerable<MeetUp> meetUps, SortingOptions filters)
        {
            meetUps = filters.SortByTitle switch
            {
                Sorting.Asc => meetUps.OrderBy(item => item.Title),
                Sorting.Desc => meetUps.OrderByDescending(item => item.Title),
                _ => meetUps
            };

            meetUps = filters.SortByDate switch
            {
                Sorting.Asc => meetUps.OrderBy(item => item.Date),
                Sorting.Desc => meetUps.OrderByDescending(item => item.Date),
                _ => meetUps
            };

            return meetUps;
        }
    }
}