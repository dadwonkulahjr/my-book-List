using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyBookList.Models;
using MyBookList.Services.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace MyBookList.Pages.Admin.BookList
{
    public class ListModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<Book> Books { get; set; }
        public ListModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
          


        }
        public IActionResult OnPostDelete(int id)
        {
            var findBookFirst = _unitOfWork.Book.GetAll(x => x.Id == id).FirstOrDefault();
            if (findBookFirst == null)
            {
                return NotFound();
            }

            _unitOfWork.Book.Delete(findBookFirst);
            _unitOfWork.Save();
            return RedirectToPage("list");
         
        }

    }
}
