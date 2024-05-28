using LMSMVC.Models;

namespace LMSMVC.Services
{
    public interface IBookService
    {
        Task<bool> Create(Book book);
        Task<bool> Update(Book book);
        Task<bool> Delete(Book book);
        Task<List<Book>> GetAll();
        Task<Book> GetById(int BookId);
    }
}
