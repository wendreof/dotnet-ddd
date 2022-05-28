using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
  public class WhenExecuteGet : UserTests
  {
    private IUserService _userService;
    private Mock<IUserService> _userServiceMock;

    [Fact(DisplayName = "It's possibile execute Get method")]
    public async void ItsPossibleExecuteGetMethod()
    {
      _userServiceMock = new Mock<IUserService>();
      _userServiceMock.Setup(x => x.Get(UserId)).ReturnsAsync(userDto);
      _userService = _userServiceMock.Object;

      var result = await _userService.Get(UserId);
      Assert.NotNull(result);
      Assert.True(result.Id == UserId);
      Assert.Equal(UserName, result.Name);

      _userServiceMock = new Mock<IUserService>();
      _userServiceMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto)null));
      _userService = _userServiceMock.Object;

      var _record = await _userService.Get(UserId);
      Assert.Null(_record);
    }
  }
}