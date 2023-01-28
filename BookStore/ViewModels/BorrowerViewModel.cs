using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels
{
    public class BorrowerViewModel
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, Range(5, 10)]
        public int NationalId { get; set; }
    }
}
