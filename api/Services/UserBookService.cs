using book_store.Models;
using book_store.Repositories;

namespace book_store.Services;

public class UserBookService : IUserBookService
{
    private readonly IUserBookRepository _userBookRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IUserRepository _userRepository;
    
    public UserBookService(IUserBookRepository userBookRepository, IBookRepository bookRepository, IUserRepository userRepository)
    {
        _userBookRepository = userBookRepository;
        _bookRepository = bookRepository;
        _userRepository = userRepository;
    }

    public async Task<bool> MakeBookFavouriteByUser(MakeBookFavaouriteRequest request)
    {
        var book = _bookRepository.Get(request.BookId);
        var user = _userRepository.Get(request.UserId);

        if (book is not null && user is not null) 
        {
            await _userBookRepository.MakeBookFavourite(request.BookId, request.UserId);
            return true;
        } 
        return false;
    }
}
