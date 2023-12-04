using book_store.Models;
using book_store.Services;
using Microsoft.AspNetCore.Mvc;

namespace book_store.Controllers;

[ApiController]
public class UserBookController : ControllerBase
{
    private readonly ILogger<BookController> _logger;
    private readonly IUserBookService _userBookService;
    public UserBookController(ILogger<BookController> logger, IUserBookService userBookService)
    {
        _userBookService = userBookService;
        _logger = logger;
    }

    [HttpPost]
    [Route("books/liked")]
    [ProducesResponseType(typeof(bool), 201)]
    [ProducesResponseType(typeof(bool), 400)]
    public async Task<IActionResult> MakeBookFavouriteByUser([FromBody] MakeBookFavaouriteRequest request)
    {
        var result = await _userBookService.MakeBookFavouriteByUser(request);
        if (result == false)
        {
            _logger.Log(LogLevel.Error, "Book was not added as favourite by user.");
            return BadRequest(result);
        }
        return Created($"books/liked?userId={request.UserId}", result);
    }
}
