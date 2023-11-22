using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace book_store.DBContext;

public class BookContext : DbContext
{                   
    public DbSet<Book> Book { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<UserBook> LikedBooks { get; set; }

    public BookContext(DbContextOptions dbContext) : base(dbContext)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserBook>().HasKey(lb => new {lb.UserId, lb.BookId});
    }
}
