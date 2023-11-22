using book_store.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace book_store.Repositories;

public class UserBookRepository : RepositoryBase<UserBook>, IUserBookRepository
{
    public UserBookRepository(BookContext dbContext) : base(dbContext)
    {

    }

    public async Task<ICollection<int>> GetBooksIdLikedByUser(int userId)
    {
        var entity = await table.Where(x => x.UserId == userId).Select(x => x.BookId).ToListAsync();
        return entity;
    }

    public async Task<bool> MakeBookFavourite(int bookId, int userId)
    {
        UserBook userBook = new UserBook() { BookId = bookId, UserId = userId };
        await Add(userBook);
        return true;
    }
}
