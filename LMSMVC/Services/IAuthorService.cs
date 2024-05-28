using LMSMVC.Models;

namespace LMSMVC.Services
{
    public interface IAuthorService
    {
        Task<bool> Create(Author author);
        Task<bool> Update(Author author);
        Task<bool> Delete(Author author);
        Task<List<Author>> GetAll();
        Task<Author> GetById(int AuthorId);
    }
}
