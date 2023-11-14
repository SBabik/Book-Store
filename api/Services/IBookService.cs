using book_store.DBContext;
using book_store.Models;

namespace book_store.Services;

public interface IBookService
{
    Task<Book?> AddBook(AddBookRequest book);
    Task<Book?> GetBook(int id);
}
