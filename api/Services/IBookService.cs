using book_store.Models;

namespace book_store.Services;

public interface IBookService
{
    Task<int> AddBook(AddBookRequest book);
}
