using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyBookList.Models;
using MyBookList.Services.Repository.IRepository;
using MyBookList.ViewModels;
using System.Linq;

namespace MyBookList.Pages.Admin.BookList
{
    public class UpsertModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;
        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public Book Book { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                Book = new();
            }


            if (id.HasValue)
            {
                Book = _unitOfWork.Book.Get(id.Value);

                if (Book == null)
                {
                    return NotFound();
                }

                return Page();
            }

            return Page();
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) { return Page(); }

            if (Book.Id == 0)
            {
                var newBook = new Book
                {
                    Name = Book.Name,
                    Author = Book.Author,
                    ISBN = Book.ISBN
                };


                _unitOfWork.Book.Add(newBook);
                _unitOfWork.Save();
                return RedirectToPage("list");
            }
            else
            {
                var result = _unitOfWork.Book.GetAll(x => x.Id == Book.Id).FirstOrDefault();

                if (result != null)
                {
                    _unitOfWork.Book.UpdateBook(Book);
                    return RedirectToPage("list");
                }

            }


            return Page();
        }

    }
}
