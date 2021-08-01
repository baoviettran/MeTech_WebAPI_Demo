using ECommerce.Data.EF;
using ECommerce.ViewModels.Catalog;
using ECommerce.ViewModels.Common;
using ECommerce.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ECommerce.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Catalog.Products
{
    public class ProductService : IProductService
    {
        private readonly ECommerceDbContext _context;
        public ProductService(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<Response<bool>> Create(ProductCreateRequest request)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Name == request.Name);
            if (product == null)
            {
                var lst = new List<ProductSupplier>();
                request.SupplierIds.ForEach(x =>
                {
                    lst.Add(new ProductSupplier() { SupplierId = x });
                });
                var newProduct = new Product()
                {
                    Name = request.Name,
                    Description = request.Description,
                    SeoTitle = request.SeoTitle,
                    Price = request.Price,
                    OriginalPrice = request.OriginalPrice,
                    CategoryId = request.CategoryId,
                    ProductSuppliers=lst,
                };
                _context.Products.Add(newProduct);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                    return new Response<bool>();
                return new Response<bool>("Thêm mới thất bại");

            }
            return new Response<bool>("Sản phẩm đã tồn tại");
        }

        public async Task<Response<bool>> Delete(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                    return new Response<bool>();
                return new Response<bool>("Xóa thất bại");
            }
            return new Response<bool>("Sản phẩm không tồn tại. Thử lại");
        }

        public Task<Response<PagedResponse<ProductVm>>> GetAllPaging(PagingRequestFilter request)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<ProductVm>> GetById(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                var productVm = new ProductVm()
                {
                    Id = id,
                    Name = product.Name,
                    SeoTitle = product.SeoTitle,
                    Price = product.Price,
                    OriginalPrice = product.OriginalPrice,
                    CategoryId = product.CategoryId
                };
                return new Response<ProductVm>(productVm);
            }
            return new Response<ProductVm>("Sản phẩm không tồn tại");
        }
        public async Task<Response<bool>> Update(Guid id, ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                product.Name = request.Name;
                product.SeoTitle = request.SeoTitle;
                product.Description = request.Description;
                product.CategoryId = request.CategoryId;
                _context.Products.Update(product);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                    return new Response<bool>();
                return new Response<bool>("Cập nhật thất bại");
            }
            return new Response<bool>("Sản phẩm không tồn tại");
        }
    }
}
