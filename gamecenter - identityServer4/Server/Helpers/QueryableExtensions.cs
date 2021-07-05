using System.Linq;
using gamecenter.Shared.DTOs;

namespace gamecenter.Server.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PageDTO pageDto)
        {
            return queryable.Skip((pageDto.Page -1) * pageDto.ItemsPerPage).Take(pageDto.ItemsPerPage);
        }
    }
}