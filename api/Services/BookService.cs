using book_store.DBContext;
using book_store.Models;
using book_store.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

namespace book_store.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IUserBookRepository _userBookRepository;
    public BookService(IBookRepository bookRepository, IUserBookRepository userBookRepository)
    {
        _bookRepository = bookRepository;
        _userBookRepository = userBookRepository;
    }

    public async Task<Book?> AddBook(AddBookRequest book)
    { 
        return await _bookRepository.AddBook(book.BookId, book.BookName);
    }

    public async Task<Book?> GetBook(int id)
    {
        return await _bookRepository.Get(id);
    }

    public async Task<ICollection<Book>> GetBooksLikedByUser(int userId)
    {
        var bookIds = await _userBookRepository.GetBooksIdLikedByUser(userId);
        return await _bookRepository.GetMany(bookIds);
    }
}
