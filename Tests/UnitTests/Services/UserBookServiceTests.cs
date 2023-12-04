using book_store.DBContext;
using book_store.Repositories;
using book_store.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Services;

public class UserBookServiceTests
{
    [Fact]
    public async Task BookService_IfRelationCreated_ReturnTrue()
    {
        var mockUserBookRepository = new Mock<IUserBookRepository>();
        var mockUserRepository = new Mock<IUserRepository>();
        var mockBookRepository = new Mock<IBookRepository>();

        mockBookRepository.Setup(f => f.Get(It.IsAny<int>())).ReturnsAsync(new Book() { Id = 1 });
        mockUserRepository.Setup(f => f.Get(It.IsAny<int>())).ReturnsAsync(new User() { Id = 1 });
        mockUserBookRepository.Setup(f => f.MakeBookFavourite(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(true);

        var mock = new UserBookService(mockUserBookRepository.Object, mockBookRepository.Object, mockUserRepository.Object, Mock.Of<ILogger<UserBookService>>());

        var result = await mock.MakeBookFavouriteByUser(new() { BookId = 1, UserId = 1 });

        result.Should().BeTrue();
    }

    [Fact]
    public async Task BookService_IfRelationExists_ReturnFalse()
    {
        var mockUserBookRepository = new Mock<IUserBookRepository>();
        var mockUserRepository = new Mock<IUserRepository>();
        var mockBookRepository = new Mock<IBookRepository>();

        mockBookRepository.Setup(f => f.Get(It.IsAny<int>())).ReturnsAsync(new Book() { Id = 1 });
        mockUserRepository.Setup(f => f.Get(It.IsAny<int>())).ReturnsAsync(new User() { Id = 1 });
        mockUserBookRepository.Setup(f => f.MakeBookFavourite(It.IsAny<int>(), It.IsAny<int>())).ThrowsAsync(new Exception());

        var mock = new UserBookService(mockUserBookRepository.Object, mockBookRepository.Object, mockUserRepository.Object, Mock.Of<ILogger<UserBookService>>());

        var result = await mock.MakeBookFavouriteByUser(new() { BookId = 1, UserId = 1 });

        result.Should().BeFalse();
    }
}

