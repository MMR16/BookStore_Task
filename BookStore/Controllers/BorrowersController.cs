using AutoMapper;
using BookStore.Models;
using BookStore.Repository;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BorrowersController : Controller
    {
        private readonly IBorrowerRepository _borrowerRepository;
        private readonly IBookBorrowerRepository _bookBorrowerRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BorrowersController(IBorrowerRepository borrowerRepository,
                                   IBookBorrowerRepository bookBorrowerRepository,
                                   IBookRepository bookRepository,
                                   IMapper mapper)
        {
            _borrowerRepository = borrowerRepository;
            _bookBorrowerRepository = bookBorrowerRepository;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            return View(_borrowerRepository.BorrowersBooks().OrderBy(e => e.Name));
        }
        public IActionResult ReturnBooks(BookBorrowerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var modelToDelete = _mapper.Map<BookBorrower>(model);
                var book = _bookRepository.GetById((int)model.BookId);
                book.Rented = false;
                book.Available = true;
                _bookRepository.Update(book);
                _bookBorrowerRepository.Delete(modelToDelete);
                return RedirectToAction("Index", "Books");
            }
            return RedirectToAction("Index");
        }
    }
}
