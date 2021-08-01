using ECommerce.ViewModels.Catalog;
using ECommerce.ViewModels.Common;
using ECommerce.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Catalog.Products
{
    public interface IProductService
    {
        Task<Response<bool>> Create(ProductCreateRequest request);
        Task<Response<bool>> Delete(Guid id);
        Task<Response<bool>> Update(Guid id, ProductUpdateRequest request);
        Task<Response<ProductVm>> GetById(Guid id);
        Task<Response<PagedResponse<ProductVm>>> GetAllPaging(PagingRequestFilter request);

    }
}
