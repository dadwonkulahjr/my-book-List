using Microsoft.AspNetCore.Mvc.Rendering;
using MyBookList.Data;
using MyBookList.Models;
using MyBookList.Services.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace MyBookList.Services.Repository
{
    //public class AuthorRepository : DefaultRepository<Author>, IAuthor
    //{
    //    private readonly AppDbContext _context;
    //    public AuthorRepository(AppDbContext appDbContext)
    //        : base(appDbContext)
    //    {
    //        _context = appDbContext;
    //    }

    //    public IEnumerable<SelectListItem> GetDropListForAuthors()
    //    {
    //        return _context.Author.Select(x => new SelectListItem()
    //        {
    //            Text = x.Name,
    //            Value = x.Id.ToString()
    //        });
    //    }

    //    public void UpdateBook(Author authorToUpdate)
    //    {
    //        var authorFound = _context.Author.FirstOrDefault(x => x.Id == authorToUpdate.Id);
    //        if (authorToUpdate != null)
    //        {
    //            authorFound.Name = authorToUpdate.Name;
    //            authorFound.Id = authorToUpdate.Id;
    //            //bookFound.AuthorId = bookToUpdate.AuthorId;
    //            _context.SaveChanges();
    //        }
    //    }
    //}
}
