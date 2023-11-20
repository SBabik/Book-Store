namespace book_store.Models;

public record AddBookRequest
{
    public required string BookId { get; set; }
    public required string BookName { get; set; }
}
