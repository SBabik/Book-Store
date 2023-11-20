using book_store.DBContext;
using book_store.Models;
using book_store.Repositories;
using book_store.Services;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Services;

public class BookServiceTests
{
    [Fact]
    public async Task BookService_WhenBookAvaible_ReturnBook()
    {
        var book = new Book() { BookId = "1", BookName = "Hary Porter Wine", Id = 1};
        var mockRepository = new Mock<IBookRepository>();
        mockRepository.Setup(f => f.Get(It.IsAny<int>())).ReturnsAsync(book);
        var mock = new BookService(mockRepository.Object);
        var result = await mock.GetBook(1);
        result.Should().NotBeNull();
        result.Id.Should().Be(1);
        result.BookName.CompareTo(book.BookName);
        result.BookId.CompareTo(book.BookId);
    }

    [Fact]
    public async Task BookService_WhenBookDoNotExist_ReturnNull()
    {
        Book? book = null;
        var mockRepository = new Mock<IBookRepository>();
        mockRepository.Setup(f => f.Get(It.IsAny<int>())).ReturnsAsync(book);
        var mock = new BookService(mockRepository.Object);
        var result = await mock.GetBook(1);
        result.Should().BeNull();
    }

    [Fact]
    public async Task BookService_IsBookAdded_ReturnBook()
    {
        var bookRequest = new AddBookRequest() { BookId = "1", BookName = "Hary Porter Wine"};
        var book = new Book() { BookId = bookRequest.BookId, BookName = bookRequest.BookName, Id = 1 };
        var mockRepository = new Mock<IBookRepository>();
        mockRepository.Setup(f => f.AddBook(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(book);
        var mock = new BookService(mockRepository.Object);
        var result = await mock.AddBook(bookRequest);
        result.Should().NotBeNull();
        result.Id.Should().Be(1);
        result.BookName.CompareTo(bookRequest.BookName);
        result.BookId.CompareTo(bookRequest.BookId);
    }

    [Fact]
    public async Task BookService_IfBookAddFails_ThrowError()
    {
        var bookRequest = new AddBookRequest() { BookId = "1", BookName = "Hary Porter Wine" };
        var mockRepository = new Mock<IBookRepository>();
        mockRepository.Setup(f => f.AddBook(It.IsAny<string>(), It.IsAny<string>())).ThrowsAsync(new Exception());
        var mock = new BookService(mockRepository.Object);
        var result = ()=>mock.AddBook(bookRequest);
        await result.Should().ThrowAsync<Exception>();
    }
}
