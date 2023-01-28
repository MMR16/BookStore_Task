using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    // [PrimaryKey(nameof(Book), nameof(Borrower))]
    public class BookBorrower
    {
        public int? BookId { get; set; }
        public Book Book { get; set; }

        public int? BorrowerId { get; set; }
        public Borrower Borrower { get; set; }
    }
}
