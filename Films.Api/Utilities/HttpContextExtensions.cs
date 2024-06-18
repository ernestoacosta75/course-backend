using Microsoft.EntityFrameworkCore;

namespace Films.Api.Utilities
{
    /// <summary>
    /// This extension will be used to paginate and return back to the frontend
    /// the quantity of records that exists in the database for the corresponding resource (tables).
    /// </summary>
    public static class HttpContextExtensions
    {
        public static async Task InsertPaginationParametersInHeader<T>(this HttpContext httpContext,
                                                                       IQueryable<T> queryable)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            double quantity = await queryable.CountAsync();
            httpContext.Response.Headers.Append("recordsTotalCount", quantity.ToString());
        }
    }
}
