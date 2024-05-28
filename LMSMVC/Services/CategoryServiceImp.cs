using Microsoft.EntityFrameworkCore;
using LMSMVC.Data;
using LMSMVC.Models;

namespace LMSMVC.Services
{
    public class CategoryServiceImp : ICategoryService
    {
        private readonly EntityDbContext _context;
        public CategoryServiceImp(EntityDbContext context)
        {
            this._context = context;
        }
        public async Task<bool> Create(Category category)
        {
            _context.Categories.Add(category);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Category category)
        {
            _context.Categories.Remove(category);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Category>> GetAll()
        {
            var results = _context.Categories;
            return await results.ToListAsync();
        }

        public  Task<Category> GetById(int CategoryId)
        {
            var category = _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == CategoryId);
            return category;
        }

        public async Task<bool> Update(Category category)
        {
            _context.Categories.Update(category);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
