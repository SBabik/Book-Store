namespace book_store.Models;

public record AddUserRequest
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Login { get; init; }
    public required string Password { get; init; }
    public required string Email { get; init; }
}