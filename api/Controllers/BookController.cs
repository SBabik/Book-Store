using book_store.DBContext;
using book_store.Models;
using book_store.Services;
using Microsoft.AspNetCore.Mvc;

namespace book_store.Controllers;

[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly ILogger<BookController> _logger;
    public BookController(IBookService bookService, ILogger<BookController> logger)
    {
        _bookService = bookService;
        _logger = logger;
    }

    [HttpPost]
    [Route("books")]
    [ProducesResponseType(typeof(Book), 201)]
    [ProducesResponseType(typeof(string), 400)]
    public async Task<IActionResult> AddBook([FromBody]AddBookRequest book)
    {
        var result = await _bookService.AddBook(book);
        if(result == null)
        {
            _logger.Log(LogLevel.Error, "Book couldn't be added.");
            return BadRequest("Book couldn't be added.");
        }
        return Ok(result);
    }

    [HttpGet]
    [Route("books/{id}")]
    [ProducesResponseType(typeof(Book), 200)]
    [ProducesResponseType(typeof(string), 400)]
    public async Task<IActionResult> Get([FromRoute]int id)
    {
        var result = await _bookService.GetBook(id);
        if(result == null)
        {
            _logger.Log(LogLevel.Error, "Book was not found, book id was incorrect.");
            return BadRequest("Book was not found, book id was incorrect.");
        }
        return Ok(result);
    }

    [HttpGet]
    [Route("books/liked")]
    [ProducesResponseType(typeof(List<Book>), 200)]
    [ProducesResponseType(typeof(string), 400)]
    public async Task<IActionResult> GetBooksLikedByUser([FromQuery]int userId)
    {
        var result = await _bookService.GetBooksLikedByUser(userId);
        if (result == null)
        {
            _logger.Log(LogLevel.Error, "User do not have liked books or user id is incorrect.");
            return BadRequest("User do not have liked books or user id is incorrect.");
        }
        return Ok(result.ToList());
    }
}

