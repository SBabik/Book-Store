﻿namespace book_store.DBContext;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public ICollection<UserBook> LikedBooks { get; set; }
}
