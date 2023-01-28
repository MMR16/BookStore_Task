using BookStore.Models;

namespace BookStore.Repository
{
    public interface IBookBorrowerRepository
    {
        public void Add(BookBorrower bookBorrower);
        public void Delete(BookBorrower bookBorrower);

    }
}
