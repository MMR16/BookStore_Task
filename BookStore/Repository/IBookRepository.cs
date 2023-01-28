using BookStore.Models;
using BookStore.ViewModels;

namespace BookStore.Repository
{
    public interface IBookRepository
    {
        public IEnumerable<Book> GetAll();
        public Book GetById(int bookId);
        public void Add(Book book);
        public void Update(Book book);
        public void Delete(int bookId);
        public bool BookExist(string bookTitle);
        public bool BookAvailable(string bookTitle);
        public IEnumerable<Book> GetAvailableBooks();

    }
}
