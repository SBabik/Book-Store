using book_store.DBContext;
using System.Collections;

namespace book_store.Repositories;

public interface ILikedBooksRepository
{
    Task<ICollection<Book>> GetBooksIdLikedByUser(int userId);
}
