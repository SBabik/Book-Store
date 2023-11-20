using book_store.DBContext;

namespace book_store.Repositories;

public class LikedBooksRepository : RepositoryBase<UserBook>, ILikedBooksRepository
{
    public LikedBooksRepository(BookContext dbContext) : base(dbContext)
    {

    }
}
