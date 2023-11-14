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

    public async Task<int> AddBook(AddBookRequest book)
    { 
        return await _bookRepository.AddBook(book.BookId, book.BookName);
    }
}
