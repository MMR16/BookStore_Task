using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BookStore.Repository
{
    public class BorrowerRepository : IBorrowerRepository
    {
        private readonly ApplicationContext _applicationContext;
        public BorrowerRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }


        public void Add(Borrower borrower)
        {
            if (borrower is null)
            {
                throw new ArgumentNullException(nameof(borrower));
            }
            _applicationContext.borrowers.Add(borrower);
            _applicationContext.SaveChanges();
        }

        public void Delete(int borrowerId)
        {
           var borrower = GetById(borrowerId);
            if (borrower is null)
            {
                throw new ArgumentNullException(nameof(borrower),$"{borrowerId} does not exist");
            }
            _applicationContext.borrowers.Remove(borrower);
            _applicationContext.SaveChanges();
        }

        public IEnumerable<Borrower> GetAll()
        {
           return _applicationContext.borrowers.ToList();
        }

        public Borrower GetById(int borrowerIid)
        {
            var borrower = _applicationContext.borrowers.Find(borrowerIid);
            return borrower;
        }

        public void Update(Borrower borrower)
        {
            var borrowerToUpdate = GetById(borrower.Id);
            if (borrowerToUpdate is null)
            {
            throw new ArgumentNullException(nameof(borrowerToUpdate), $"{borrower.Name} does not exist");
            }
            _applicationContext.borrowers.Update(borrowerToUpdate);
            _applicationContext.SaveChanges();
        }

        public IEnumerable<Borrower> BorrowersBooks()
        {
            return _applicationContext.borrowers.Include(e => e.BookBorrowers).ThenInclude(e => e.Book);
        }

    }
}
