using BookStore.Models;

namespace BookStore.Repository
{
    public class BookBorrowerRepository : IBookBorrowerRepository
    {
        private readonly ApplicationContext _applicationContext;

        public BookBorrowerRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public void Add(BookBorrower bookBorrower)
        {
            _applicationContext.bookBorrowers.Add(bookBorrower);
            _applicationContext.SaveChanges();
        }

        public void Delete(BookBorrower bookBorrower)
        {
            _applicationContext.bookBorrowers.Remove(bookBorrower);
            _applicationContext.SaveChanges();
        }
    }
}
