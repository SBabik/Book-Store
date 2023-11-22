using book_store.Models;

namespace book_store.Services;

public interface IUserBookService
{
    Task<bool> MakeBookFavouriteByUser(MakeBookFavaouriteRequest request);
}
