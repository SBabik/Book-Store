using book_store.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace book_store.Repositories;

public class BookRepository : RepositoryBase<Book>, IBookRepository
{
    public BookRepository(BookContext dbContext) : base(dbContext)
    {
        
    }
    public async Task<Book> AddBook(string id, string name)
    {
        var book = new Book()
        {
            BookId = id,
            BookName = name
        };
        await Add(book);
        return book;
    }

    public async Task<Book?> Get(int id)
    {
        var entity = await table.FindAsync(id);
        return entity;
    }

    public async Task<ICollection<Book>> GetMany(ICollection<int> ids)
    {
        return await table.Where(x => ids.Contains(x.Id)).ToListAsync();
    }


}
