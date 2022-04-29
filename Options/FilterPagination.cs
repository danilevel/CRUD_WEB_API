namespace CRUD_WEB_API.Options
{
    public static class FilterPagination
    {
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> source, Pagination pagination) =>
            source.Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize);
    }
}