using Microsoft.EntityFrameworkCore;
using Zigzag.Library.API.Infra.Data;
using Zigzag.Library.API.Model;

namespace Zigzag.Library.API.Repository;

public class BookRepository : BaseRepository<ZigzagDbContext>, IBookRepository
{
    private readonly ILogger<BookRepository> _logger;
    public BookRepository(ZigzagDbContext context, ILogger<BookRepository> logger) : base(context)
    {
        _logger = logger;
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        return await _dbContext.Books.ToListAsync();
    }

    public async Task<Book?> GetBookByIdAsync(int id)
    {
        return await _dbContext.Books.FindAsync(id);
    }

    public async Task<Book> AddBookAsync(Book book)
    {
        try
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            AppendError($"Error: {e.Message}");
        }
       
        return book;
    }

    public async Task UpdateBookAsync(Book bookParam)
    {
        try
        {
            var book = _dbContext.Books.Find(bookParam.Id);

            if (book != null)
            {
                book.Author = bookParam.Author;
                book.Title = bookParam.Title;
                book.Isbn = bookParam.Isbn;
                book.PublishedDate = bookParam.PublishedDate;

                _dbContext.Books.Update(book);

                await _dbContext.SaveChangesAsync();
            }
            else
            {
                AppendError($"Error: Book Not found");
            }    
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            AppendError($"Error: {e.Message}");
        }
    }

   
}
