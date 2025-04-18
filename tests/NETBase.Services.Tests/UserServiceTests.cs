using Moq;
using NETBase.DTOs;
using NETBase.Interfaces.IRepositories;
using NETBase.Interfaces.IServices;
using NETBase.Models;

namespace NETBase.Services.Tests;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _repoMock;
    private readonly UserService _userService;

    public UserServiceTests()
    {
        _repoMock = new Mock<IUserRepository>();
        _userService = new UserService(_repoMock.Object);
    }

    [Fact]
    public async Task GetUserByCode_ReturnsUserDTO_WhenUserExists()
    {
        // Arrange
        var userCode = "ABC123";
        var user = new User
        {
            Code = userCode,
            Username = "TestUser",
            Email = "test@example.com",
            Password = "securePassword"
        };

        _repoMock.Setup(repo => repo.GetUserByCode(userCode))
                 .ReturnsAsync(user);

        // Act
        var result = await _userService.GetUserByCode(userCode);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<UserDTO>(result);
        Assert.Equal(userCode, result.Code);
        Assert.Equal(user.Username, result.Username);
        Assert.Equal(user.Email, result.Email);
        Assert.Equal(user.Password, result.Password);
    }

    [Fact]
    public async Task GetUserByCode_ThrowsException_WhenUserDoesNotExist()
    {
        // Arrange
        var userCode = "INVALID_CODE";

        _repoMock.Setup(repo => repo.GetUserByCode(userCode))
                 .ReturnsAsync((User)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<Exception>(
            () => _userService.GetUserByCode(userCode));

        Assert.Equal("User does not exists!", exception.Message);
    }
}
