using book_store.DBContext;

namespace book_store.Repositories;

public interface IBookRepository
{
    Task<Book> AddBook(string id, string name);
    Task<Book?> Get(int id);
    Task<ICollection<Book>> GetMany(ICollection<int> ids);
}
