using book_store.DBContext;
using book_store.Models;
using book_store.Repositories;

namespace book_store.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Book?> AddBook(AddBookRequest book)
    { 
        return await _bookRepository.AddBook(book.BookId, book.BookName);
    }

    public async Task<Book?> GetBook(int id)
    {
        return await _bookRepository.Get(id);
    }

    public async Task<List<Book>> GetBooksForUser(int userId)
    {
        
        return
    }
}
