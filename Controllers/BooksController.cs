using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBookList.Services.Repository.IRepository;
using System.Linq;

namespace MyBookList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Book.GetAll().OrderBy(x => x.Name).ToList() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var bookObj = _unitOfWork.Book.Get(id);
            if (bookObj == null)
            {
                return Json(new { success = false, message = "Error why deleting." });
            }

            _unitOfWork.Book.Delete(bookObj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });

        }

    }
}
