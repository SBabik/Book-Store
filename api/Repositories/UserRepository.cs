using book_store.DBContext;

namespace book_store.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(BookContext dbContext) : base(dbContext)
    {

    }

    public async Task<User> AddUser(string firstName, string lastName, string login, string password, string email)
    {
        var user = new User()
        {
            FirstName = firstName,
            LastName = lastName,
            Login = login,
            Password = password,
            Email = email
        };
        user = await Add(user);
        return user;
    }
}
