using book_store.DBContext;
using book_store.Repositories;
using book_store.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookContext>(opts =>
{
    opts.UseMySql("Server=127.0.0.1;Database=BookStore;Uid=root;Pwd=;", new MySqlServerVersion(new Version(8, 0, 29)));
});

builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IBookRepository, BookRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
