using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
  public class WhenExecuteUpdate : UserTests
  {
    private IUserService _userService;
    private Mock<IUserService> _userServiceMock;

    [Fact(DisplayName = "It's possibile execute Update method")]
    public async void ItsPossibleExecuteUpdateMethod()
    {
      _userServiceMock = new Mock<IUserService>();
      _userServiceMock.Setup(x => x.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
      _userService = _userServiceMock.Object;

      var _result = await _userService.Post(userDtoCreate);
      Assert.NotNull(_result);
      Assert.Equal(userDtoCreateResult.Name, _result.Name);
      Assert.Equal(userDtoCreateResult.Email, _result.Email);

      _userServiceMock = new Mock<IUserService>();
      _userServiceMock.Setup(x => x.Put(userDtoUpdate)).ReturnsAsync(userDtoUpdateResult);
      _userService = _userServiceMock.Object;

      var _resultUpdate = await _userService.Put(userDtoUpdate);
      Assert.NotNull(_resultUpdate);
      Assert.Equal(UserNameModified, _resultUpdate.Name);
      Assert.Equal(UserEmailModified, _resultUpdate.Email);
    }
  }
}