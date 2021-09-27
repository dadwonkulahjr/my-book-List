using MyBookList.Data;
using MyBookList.Services.Repository.IRepository;
using System;


namespace MyBookList.Services.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext appDbContext)
        {
            Book = new BookRepository(appDbContext);
            //Author = new AuthorRepository(appDbContext);
            _context = appDbContext;
        }
        public IBook Book { get; private set; }

        //public IAuthor Author { get; private set; }

        public void Dispose() => GC.SuppressFinalize(this);

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
