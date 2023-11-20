using book_store.DBContext;
using System.Numerics;

namespace book_store.Repositories;

public interface IUserRepository
{
    Task<User> AddUser(string firstName,
                       string lastName,
                       string login,
                       string password,
                       string email);
    Task<User?> Get(int id);
}
         
