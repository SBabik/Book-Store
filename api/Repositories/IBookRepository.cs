namespace book_store.Repositories;

public interface IBookRepository
{
    Task<int> AddBook(string id, string name);
}
