using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBookList.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Author { get; set; }
        [StringLength(50)]
        public string ISBN { get; set; }



    }
}
