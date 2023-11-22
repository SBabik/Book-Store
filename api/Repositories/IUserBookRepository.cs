using book_store.DBContext;
using book_store.Models;
using System.Collections;

namespace book_store.Repositories;

public interface IUserBookRepository
{
    Task<ICollection<int>> GetBooksIdLikedByUser(int userId);
    Task<bool> MakeBookFavourite(int bookId, int userId);
}
