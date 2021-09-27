using MyBookList.Data;
using MyBookList.Models;
using MyBookList.Services.Repository.IRepository;
using System.Linq;

namespace MyBookList.Services.Repository
{
    public class BookRepository : DefaultRepository<Book>, IBook
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
            _context = appDbContext;
        }
        public void UpdateBook(Book bookToUpdate)
        {
            var bookFound = _context.Books.FirstOrDefault(x => x.Id == bookToUpdate.Id);
            if (bookToUpdate != null)
            {
                bookFound.Name = bookToUpdate.Name;
                bookFound.Author = bookToUpdate.Author;
                bookFound.ISBN = bookToUpdate.ISBN;
                _context.SaveChanges();
            }
        }
    }
}
