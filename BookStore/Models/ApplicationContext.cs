using BookStore.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookBorrower>().HasKey(x => new { x.BookId, x.BorrowerId });
            modelBuilder.Entity<BookBorrower>().HasOne(e => e.Book).WithMany(q => q.BookBorrowers).HasForeignKey(r => r.BookId);
            modelBuilder.Entity<BookBorrower>().HasOne(e => e.Borrower).WithMany(q => q.BookBorrowers).HasForeignKey(r => r.BorrowerId);

            Seed(modelBuilder);
        }
        public DbSet<Book> books { get; set; }
        public DbSet<Borrower> borrowers { get; set; }
        public DbSet<BookBorrower> bookBorrowers { get; set; }
        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Borrower>().HasData(
                        new Borrower { Id = 1, Name = "Mostafa", NationalId = 120365 },
                        new Borrower { Id = 2, Name = "Ali", NationalId = 787454 },
                        new Borrower { Id = 3, Name = "Ahmed", NationalId = 477449 },
                        new Borrower { Id = 4, Name = "Alaa", NationalId = 8854471 }
                        );
            modelBuilder.Entity<Book>().HasData(
                new Book { Available = false, Id = 1, Title = "dotnet", Author = "Microsoft", Code = "as123", Rented = true },
                new Book { Available = false, Id = 2, Title = "dotnet", Author = "Microsoft", Code = "as456", Rented = true },
                new Book { Available = false, Id = 3, Title = "dotnet", Author = "Microsoft", Code = "as789", Rented = true },
                new Book { Available = false, Id = 4, Title = "Angular", Author = "Google", Code = "we1111", Rented = true },
                new Book { Available = false, Id = 5, Title = "Angular", Author = "Google", Code = "we9874", Rented = true },
                new Book { Available = false, Id = 6, Title = "React", Author = "FaceBook", Code = "tr2515", Rented = true },
                new Book { Available = false, Id = 7, Title = "Java", Author = "Sun Microsystems", Code = "bv4564", Rented = true },
                new Book { Available = true, Id = 8, Title = "dotnet", Author = "Microsoft", Code = "gf444", Rented = false },
                new Book { Available = true, Id = 9, Title = "dotnet", Author = "Microsoft", Code = "trt77", Rented = false },
                new Book { Available = true, Id = 10, Title = "dotnet", Author = "Microsoft", Code = "gf5596", Rented = false },
                new Book { Available = true, Id = 11, Title = "Angular", Author = "Google", Code = "tr9963", Rented = false },
                new Book { Available = true, Id = 12, Title = "Angular", Author = "Google", Code = "uy5512", Rented = false }
                );

            modelBuilder.Entity<BookBorrower>().HasData(
                       new BookBorrower { BorrowerId = 1, BookId = 1 },
                       new BookBorrower { BorrowerId = 1, BookId = 3 },
                       new BookBorrower { BorrowerId = 1, BookId = 7 },
                       new BookBorrower { BorrowerId = 2, BookId = 2 },
                       new BookBorrower { BorrowerId = 2, BookId = 4 },
                       new BookBorrower { BorrowerId = 3, BookId = 5 },
                       new BookBorrower { BorrowerId = 4, BookId = 6 }
                       );
        }
    }
}
