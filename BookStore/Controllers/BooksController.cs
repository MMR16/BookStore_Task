using AutoMapper;
using BookStore.Models;
using BookStore.Repository;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly IBorrowerRepository _borrowerRepository;
        private readonly IBookBorrowerRepository _bookBorrowerRepository;

        public BooksController(IBookRepository bookRepository,
                               IMapper mapper,
                               IBorrowerRepository borrowerRepository,
                               IBookBorrowerRepository bookBorrowerRepository)

        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _borrowerRepository = borrowerRepository;
            _bookBorrowerRepository = bookBorrowerRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var books = _bookRepository.GetAvailableBooks().OrderBy(e => e.Title);
            return View(books);
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddBook(BookViewModel book)
        {
            var bookToAdd = _mapper.Map<Book>(book);
            _bookRepository.Add(bookToAdd);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetBooks()
        {
            var books = _bookRepository.GetAll().OrderBy(e => e.Title);
            return View(books);
        }

        [HttpGet]
        public IActionResult Rentbook(int id)
        {
            ViewBag.Id = id;
            ViewBag.bookName = _bookRepository.GetById(id).Title;
            //  List<Borrower> borrowers= new List<Borrower>();
            var borrowers = _borrowerRepository.GetAll().Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });
            return View(borrowers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Rentbook(BookBorrowerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var modelToAdd = _mapper.Map<BookBorrower>(model);
                var book = _bookRepository.GetById((int)model.BookId);
                book.Rented = true;
                book.Available = false;
                _bookRepository.Update(book);
                _bookBorrowerRepository.Add(modelToAdd);
                return RedirectToAction("Index", "Borrowers");
            }
            return RedirectToAction("Rentbook", ModelState.ErrorCount);
        }
    }
}
