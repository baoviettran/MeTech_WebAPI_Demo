using ECommerce.Application.Common;
using ECommerce.Data.EF;
using ECommerce.Data.Entities;
using ECommerce.ViewModels.Catalog.Category;
using ECommerce.ViewModels.Common;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ECommerceDbContext _context;

        public CategoryService(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<Response<bool>> DeleteOne(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return new Response<bool>("Danh mục không tồn tại");
            _context.Categories.Remove(category);
            var result = await _context.SaveChangesAsync();
            if (result < 1)
                return new Response<bool>("Xóa thất bại");
            return new Response<bool>("Xóa thành công");
        }

        public Task<Response<PagedResponse<CategoryVm>>> GetAllPaging(PagingRequestFilter request)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<CategoryVm>> GetById(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return new Response<CategoryVm>("Not found");
            var categoryVm = new CategoryVm()
            {
                Id = category.Id,
                Name = category.Name,
                SeoTitle = category.SeoTitle
            };
            return new Response<CategoryVm>(categoryVm);
        }

        public async Task<Response<bool>> InsertOne(CategoryCreateRequest request)
        {
            var category = _context.Categories.Where(c => c.Name == request.Name).FirstOrDefault();
            if (category != null)
                return new Response<bool>("Danh mục đã tồn tại");
            var newCategory = new Category()
            {
                Name = request.Name,
                SeoTitle = request.SeoTitle,
            };

            _context.Categories.Add(newCategory);
            var result = await _context.SaveChangesAsync();
            if (result < 1)
                return new Response<bool>("Insert failed");
            return new Response<bool>();
        }

        public async Task<Response<bool>> Update(int id, CategoryUpdateRequest request)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return new Response<bool>("Not found");
            category.Name = request.Name;
            category.SeoTitle = request.SeoTitle;
            _context.Categories.Update(category);
            var result = await _context.SaveChangesAsync();
            if (result < 1)
                return new Response<bool>("Update failed");
            return new Response<bool>();
        }
    }
}