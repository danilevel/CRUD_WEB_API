using CRUD_WEB_API.DTO;

namespace CRUD_WEB_API.Options
{
    public static class SearchingMeetUp
    {
        public static IEnumerable<MeetUp> Search(this IEnumerable<MeetUp> meetUps, string substring)
        {
            var resultTitle = meetUps.Where(item => item.Title.ToLower().Contains(substring.ToLower()));
            var resultTags = meetUps.Where(item => item.Tags.Contains(substring));

            return resultTitle.Union(resultTags);
        }
    }
}