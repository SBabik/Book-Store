namespace book_store.Models;

public record MakeBookFavaouriteRequest
{
    public int UserId { get; init; } 
    public int BookId { get; init; }
}
