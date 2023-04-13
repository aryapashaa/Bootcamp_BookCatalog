using BookCatalog_API.Contexts;
using BookCatalog_API.Models;
using BookCatalog_API.Repositories;

namespace BookCatalog_API.Repositories.Data;

public class BookRepository : GeneralRepository<int, Book>
{
    public BookRepository(MyContext context) : base(context)
    {
    }

    //public async List<BookVM> GetBookPublisher()
    //{
    //    var results = (from b in GetAll()
    //                   join p in publisherRepository.GetAll()
    //                   on b.Publisher equals p.Books
    //                   select new BookVM
    //                   {
    //                       Id = b.Id,
    //                       Isbn = b.Isbn,
    //                       Title = b.Title,
    //                       ReleaseYear = b.ReleaseYear,
    //                       Synopsis = b.Synopsis,
    //                       PageNumber = b.PageNumber,
    //                       Price = b.Price,
    //                       Genre = b.Genre,
    //                       PictureUrl = b.PictureUrl,
    //                       PublisherName = p.Name
    //                   }).ToList();
    //    return results;
    //}
}
