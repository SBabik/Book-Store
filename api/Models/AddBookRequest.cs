namespace book_store.Models;

public record AddBookRequest
{
    public required string BookId { get; init; }
    public required string BookName { get; init; }
}
