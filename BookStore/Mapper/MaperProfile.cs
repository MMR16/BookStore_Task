using AutoMapper;
using BookStore.Models;
using BookStore.ViewModels;

namespace BookStore.Mapper
{
    public class MaperProfile: Profile
    {
        public MaperProfile()
        {
            CreateMap<BookBorrower, BookBorrowerViewModel>();
            CreateMap<BookBorrower, BookBorrowerViewModel>().ReverseMap();

            CreateMap<Book, BookViewModel>();
            CreateMap<Book, BookViewModel>().ReverseMap();

            CreateMap<Borrower, BorrowerViewModel>();
            CreateMap<Borrower, BorrowerViewModel>().ReverseMap();
        }
    }
}
