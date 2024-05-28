using Microsoft.EntityFrameworkCore;
using LMSMVC.Data;
using LMSMVC.Models;

namespace LMSMVC.Services
{
    public class AuthorServiceImpl : IAuthorService
    {
        private readonly EntityDbContext _context;
        public AuthorServiceImpl(EntityDbContext context)
        {
            this._context = context;
        }
        public async Task<bool> Create(Author author)
        {
            _context.Authors.Add(author);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Author author)
        {
            _context.Authors.Remove(author);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Author>> GetAll()
        {
            var result= _context.Authors;
            return await result.ToListAsync();
        }

        public  Task<Author> GetById(int AuthorId)
        {
            var author = _context.Authors.FirstOrDefaultAsync(x => x.AuthorId == AuthorId);
            return author;
        }

        public async Task<bool> Update(Author author)
        {
           _context.Authors.Update(author);
            return await _context.SaveChangesAsync() >0;
        }
    }
}
