using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required,MaxLength(300)]
        public string Title { get; set; }

        [Required, MaxLength(10)]
        public string Code { get; set; }

        [Required]
        public string Author { get; set; }
        public bool Rented { get; set; }
        public bool Available { get; set; }

        public ICollection<BookBorrower> BookBorrowers { get; set; } = new HashSet<BookBorrower>();

    }
}
