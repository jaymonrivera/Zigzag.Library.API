using Zigzag.Library.API.Interfaces;
using Zigzag.Library.API.Model;

namespace Zigzag.Library.API.Repository;

public interface IBookRepository : IZigzagRepository
{
    Task<IEnumerable<Book>> GetAllBooksAsync();
    Task<Book?> GetBookByIdAsync(int id);
    Task<Book> AddBookAsync(Book book);
    Task UpdateBookAsync(Book book);
}
