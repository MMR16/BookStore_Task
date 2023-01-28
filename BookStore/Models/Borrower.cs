using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Borrower
    {
        [Key]
        public int Id { get; set; }

        [Required,MaxLength(100)]
        public string Name { get; set; }

        [Required, Range(5,10)]
        public int NationalId { get; set; }

        public ICollection<BookBorrower> BookBorrowers { get; set; } = new HashSet<BookBorrower>();

    }
}
