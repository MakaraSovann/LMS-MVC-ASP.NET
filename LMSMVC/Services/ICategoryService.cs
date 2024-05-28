using LMSMVC.Models;

namespace LMSMVC.Services
{
    public interface ICategoryService
    {
        Task<bool> Create(Category category);
        Task<bool> Update(Category category);
        Task<bool> Delete(Category category);
        Task<List<Category>> GetAll();
        Task<Category> GetById(int CategoryId);
    }
}
