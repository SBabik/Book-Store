using book_store.Models;
using book_store.Repositories;

namespace book_store.Services;

public class UserBookService : IUserBookService
{
    private readonly IUserBookRepository _userBookRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IUserRepository _userRepository;
    private readonly ILogger<UserBookService> _logger;
    
    public UserBookService(IUserBookRepository userBookRepository, IBookRepository bookRepository, IUserRepository userRepository, ILogger<UserBookService> logger)
    {
        _userBookRepository = userBookRepository;
        _bookRepository = bookRepository;
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task<bool> MakeBookFavouriteByUser(MakeBookFavaouriteRequest request)
    {
        var book = _bookRepository.Get(request.BookId);
        var user = _userRepository.Get(request.UserId);

        if (book is null || user is null) 
        {
            return false;
        }
        
        try
        {
            await _userBookRepository.MakeBookFavourite(request.BookId, request.UserId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Database threw an error");
            return false;
        }

        return true;
    }
}
