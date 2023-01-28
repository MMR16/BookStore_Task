using BookStore.Mapper;
using BookStore.Models;
using BookStore.ViewModels;
using System.Diagnostics.Metrics;

namespace BookStore.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationContext _applicationContext;

        public BookRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void Add(Book book)
        {
            if (book is null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            _applicationContext.books.Add(book);
            _applicationContext.SaveChanges();
        }
        public void Delete(int bookId)
        {
            var book = GetById(bookId);
            if (book is null)
            {
                throw new ArgumentNullException(nameof(book), $"{bookId} does not exist");
            }
            _applicationContext.books.Remove(book);
            _applicationContext.SaveChanges();
        }
        public IEnumerable<Book> GetAll()
        {
            return _applicationContext.books.ToList();
        }
        public Book GetById(int bookId)
        {
            var book = _applicationContext.books.Find(bookId);
            return book;
        }
        public void Update(Book book)
        {
            var bookToUpdate = GetById(book.Id);
            if (bookToUpdate is not null)
            {
                _applicationContext.books.Update(bookToUpdate);
                _applicationContext.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException(nameof(bookToUpdate), $"{book.Title} does not exist");
            }
        }
        public bool BookExist(string bookTitle)
        {
            return _applicationContext.books.Any(book => book.Title == bookTitle);
        }
        public bool BookAvailable(string bookTitle)
        {
            if (BookExist(bookTitle) is false)
            {
                return false;
            }
            return _applicationContext.books.First(book => book.Title == bookTitle).Available;
        }
        public IEnumerable<Book> GetAvailableBooks()
        {
            return _applicationContext.books.Where(e => e.Available == true).ToList();
        }

    }
}
