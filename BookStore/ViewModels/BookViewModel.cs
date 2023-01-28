using BookStore.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels
{
    public class BookViewModel
    {
        [Required, MaxLength(300)]
        public string Title { get; set; }

        [Required, MaxLength(10)]
        public string Code { get; set; }

        [Required]
        public string Author { get; set; }

        [ForeignKey(nameof(borrower))]
        public int BorrowerId { get; set; }
        public Borrower borrower { get; set; }
        public bool Rented { get; set; } = false;
        public bool Available { get; set; }

    }
}
