using Films.Core.Application.Models;

namespace course_backend.Utilities
{
    /// <summary>
    /// Since the pagination can occurs from different places,
    /// this extension will centralize this kind of operation in EF Core.
    /// </summary>
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable,
                                                PaginationDto paginationDto)
        {
            return queryable
                .Skip((paginationDto.Page - 1) * paginationDto.RecordsPerPage)
                .Take(paginationDto.RecordsPerPage);
        }
    }
}
