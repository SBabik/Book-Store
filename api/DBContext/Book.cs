namespace book_store.DBContext;

public class Book
{
    public int Id { get; set; }
    public User User { get; set; }
    public string BookId { get; set; }
    public string BookName { get; set; }
    public ICollection<UserBook> LikedBooks { get; set;}
}
