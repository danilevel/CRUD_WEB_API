using CRUD_WEB_API.Models;

namespace CRUD_WEB_API.SearchingModels
{
    public static class SearchingMeetUp
    {
        public static IQueryable<MeetUp> Search(this IQueryable<MeetUp> meetUps, string substring)
        {
            var resultTitle = meetUps.Where(item => item.Title.Contains(substring));
            var resultTags = meetUps.Where(item => item.Tags.Contains(substring));

            return resultTitle.Union(resultTags);
        }
    }
}