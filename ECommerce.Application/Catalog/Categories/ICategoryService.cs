using ECommerce.ViewModels.Catalog.Category;
using ECommerce.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<Response<bool>> InsertOne(CategoryCreateRequest request);

        Task<Response<bool>> Update(int id, CategoryUpdateRequest request);

        Task<Response<bool>> DeleteOne(int id);

        Task<Response<CategoryVm>> GetById(int id);

        Task<Response<PagedResponse<CategoryVm>>> GetAllPaging(PagingRequestFilter request);
    }
}