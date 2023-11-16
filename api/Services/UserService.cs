using book_store.DBContext;
using book_store.Models;
using book_store.Repositories;

namespace book_store.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> AddUser(AddUserRequest user)
    {
        return await _userRepository.AddUser(
            user.FirstName,
            user.LastName,
            user.Login,
            user.Password,
            user.Email);
    }

    public async Task<User?> GetUser(int id)
    {
        return await _userRepository.Get(id);
    }
}
