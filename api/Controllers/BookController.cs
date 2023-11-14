using book_store.DBContext;
using book_store.Models;
using book_store.Services;
using Microsoft.AspNetCore.Mvc;

namespace book_store.Controllers;

[ApiController]
[Route("[controller]")]
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
    [Route("book")]
    public async Task<IActionResult> AddBook([FromBody]AddBookRequest book)
    {
        var result = await _bookService.AddBook(book);
        if(result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }

    [HttpGet]
    [Route("book/{id}")]
    public async Task<IActionResult> Get([FromRoute]int id)
    {
        var result = await _bookService.GetBook(id);
        if(result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }
}
