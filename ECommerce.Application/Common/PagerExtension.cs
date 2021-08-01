using ECommerce.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Common
{
    public static class PagerExtension
    {
        public static async Task<PagedResponse<TModel>> PagingDataAsync<TModel>(this IQueryable<TModel> query, int currentPage = 1, int limit = 10)
        {
            currentPage = (currentPage < 1) ? 1 : currentPage;
            var paged = new PagedResponse<TModel>();

            var totalRecords = query.Count();
            var skipRow = (currentPage - 1) * limit;
            paged.Data = await query.Skip(skipRow).Take(limit).ToListAsync();
            paged.TotalRecords = totalRecords;
            paged.TotalPages = (int)Math.Ceiling(totalRecords / (double)limit);
            return paged;
        }
    }
}