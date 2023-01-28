using System.ComponentModel.DataAnnotations;
using BookStore.Models;

namespace BookStore.ViewModels
{
    public class BookBorrowerViewModel
    {
        [Required]
        public int? BookId { get; set; }
        [Required]
        public int? BorrowerId { get; set; }
    }
}
