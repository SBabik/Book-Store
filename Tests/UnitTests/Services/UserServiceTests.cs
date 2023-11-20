using book_store.DBContext;
using book_store.Migrations;
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
using User = book_store.DBContext.User;

namespace UnitTest.Services;

public class UserServiceTests
{
    [Fact]
    public async Task UserService_WhenUserAvaible_ReturnUser()
    {
        var user = new User()
        {
            FirstName = "Harry",
            LastName = "Porter",
            Login = "HAR",
            Password = "POT",
            Email = "good.wine@outlook.com",
            Id = 1
        };
        var mockRepository = new Mock<IUserRepository>();
        mockRepository.Setup(f => f.Get(It.IsAny<int>())).ReturnsAsync(user);
        var mock = new UserService(mockRepository.Object);
        var result = await mock.GetUser(1);
        result.Should().NotBeNull();
        result.Id.Should().Be(1);
        result.FirstName.CompareTo(user.FirstName);
        result.LastName.CompareTo(user.LastName);
        result.Login.CompareTo(user.Login);
        result.Password.CompareTo(user.Password);
    }

    [Fact]
    public async Task UserService_WhenUserDoNotExist_ReturnNull()
    {
        User? user = null;
        var mockRepository = new Mock<IUserRepository>();
        mockRepository.Setup(f => f.Get(It.IsAny<int>())).ReturnsAsync(user);
        var mock = new UserService(mockRepository.Object);
        var result = await mock.GetUser(1);
        result.Should().BeNull();
    }

    [Fact]
    public async Task UserService_IsUserAdded_ReturnUser()
    {
        var userRequest = new AddUserRequest()
        {
            FirstName = "Harry",
            LastName = "Porter",
            Login = "HAR",
            Password = "POT",
            Email = "good.wine@outlook.com"
        };
        var user = new User()
        {
            FirstName = userRequest.FirstName,
            LastName = userRequest.LastName,
            Login = userRequest.Login,
            Password = userRequest.Password,
            Email = userRequest.Email,
            Id = 1
        };
        var mockRepository = new Mock<IUserRepository>();
        mockRepository.Setup(f => f.AddUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(user);
        var mock = new UserService(mockRepository.Object);
        var result = await mock.AddUser(userRequest);
        result.Should().NotBeNull();
        result.Id.Should().Be(1);
        result.FirstName.CompareTo(user.FirstName);
        result.LastName.CompareTo(user.LastName);
        result.Login.CompareTo(user.Login);
        result.Password.CompareTo(user.Password);
    }

    [Fact]
    public async Task UserService_IfUserAddFails_ThrowError()
    {
        var userRequest = new AddUserRequest()
        {
            FirstName = "Harry",
            LastName = "Porter",
            Login = "HAR",
            Password = "POT",
            Email = "good.wine@outlook.com",
        };
        var mockRepository = new Mock<IUserRepository>();
        mockRepository.Setup(f => f.AddUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).ThrowsAsync(new Exception());
        var mock = new UserService(mockRepository.Object);
        var result = ()=> mock.AddUser(userRequest);
        await result.Should().ThrowAsync<Exception>();
    }
}
