using book_store.DBContext;
using book_store.Models;

namespace book_store.Services;

public interface IUserService
{
    Task<User?> AddUser(AddUserRequest user);
    Task<User?> GetUser(int id);
}
