using Microsoft.AspNetCore.Mvc.Rendering;
using MyBookList.Models;
using System.Collections.Generic;

namespace MyBookList.ViewModels
{
    public class BookViewModel
    {
        public Book Book { get; set; } = new();
        public IEnumerable<SelectListItem> DropdownList { get; set; }
    }
}
