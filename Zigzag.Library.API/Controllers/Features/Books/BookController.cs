using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zigzag.Library.API.Controllers.Features.Books.Dtos;
using Zigzag.Library.API.Model;
using Zigzag.Library.API.Repository;
using Zigzag.Library.API.Services;
using static System.Reflection.Metadata.BlobBuilder;

namespace Zigzag.Library.API.Controllers.Features.Books;

[ApiController]
public class BookController : ZigzagBaseController
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;
    private readonly JwtService _jwtService;

    public BookController(IBookRepository bookRepository, IMapper mapper, JwtService jwtService)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        _jwtService = jwtService;
    }

    /// <summary>
    /// Generate Token
    /// </summary>
    [HttpGet("token")]
    public IActionResult GetToken()
    {
        var token = _jwtService.GenerateToken(1, "jaymon");
        return Ok(token);
    }

    /// <summary>
    /// Get all books
    /// </summary>
    [Authorize]
    [HttpGet("books")]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _bookRepository.GetAllBooksAsync();
        var result = _mapper.Map<IEnumerable<BooksDto>>(books);
        return CreateApiResponse(_bookRepository, result);
    }

    /// <summary>
    /// Add a new book
    /// </summary>
    [Authorize]
    [HttpPost("book")]
    public async Task<ActionResult<Book>> CreateBook([FromBody] BookParamDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);

        var newBook = await _bookRepository.AddBookAsync(book);
        return CreateApiResponse(_bookRepository, newBook);
    }


    /// <summary>
    /// Get a specific book
    /// </summary>
    [Authorize]
    [HttpGet("book/{id}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        var book = await _bookRepository.GetBookByIdAsync(id);
        if (book == null)
        {
            return NotFound("Book Not found");
        }
        var dto = _mapper.Map<BooksDto>(book);
        return CreateApiResponse(_bookRepository, dto);
    }

    /// <summary>
    /// Update a book
    /// </summary>
    [Authorize]
    [HttpPut("book/{id}")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] BookParamDto updatedBookDto)
    {

        var book = await _bookRepository.GetBookByIdAsync(id);

        if (book == null)
        {
            return NotFound("Book Not found");
        }

        var updatedBook = _mapper.Map<Book>(updatedBookDto);
        updatedBook.Id = id;

        await _bookRepository.UpdateBookAsync(updatedBook);
        return CreateApiResponse(_bookRepository, updatedBook);
    }


}