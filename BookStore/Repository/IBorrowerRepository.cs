using BookStore.Models;

namespace BookStore.Repository
{
    public interface IBorrowerRepository
    {
        public IEnumerable<Borrower> GetAll();
        public Borrower GetById(int borrowerIid);
        public void Add(Borrower borrower);
        public void Update(Borrower borrower);
        public void Delete(int borrowerId);
        public IEnumerable<Borrower> BorrowersBooks();


    }
}
