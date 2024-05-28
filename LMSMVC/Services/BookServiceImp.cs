using Microsoft.EntityFrameworkCore;
using LMSMVC.Data;
using LMSMVC.Models;

namespace LMSMVC.Services
{
    public class BookServiceImp : IBookService
    {
        private readonly EntityDbContext _context;
        public BookServiceImp(EntityDbContext context)
        {
            this._context = context;
        }
        public async Task<bool> Create(Book book)
        {
            _context.Books.Add(book);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Book book)
        {
           _context.Books.Remove(book);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Book>> GetAll()
        {
            var result = _context.Books;
            return await result.ToListAsync();
        }

        public Task<Book> GetById(int BookId)
        {
            var book = _context.Books.FirstOrDefaultAsync(x => x.BookId == BookId);
            return book;
        }

        public async Task<bool> Update(Book book)
        {
           _context.Books.Update(book);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
