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

            var result = await _userService.Post(userDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(userDtoCreateResult.Name, result.Name);
            Assert.Equal(userDtoCreateResult.Email, result.Email);

            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(x => x.Put(userDtoUpdate)).ReturnsAsync(userDtoUpdateResult);
            _userService = _userServiceMock.Object;

            var resultUpdate = await _userService.Put(userDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(UserNameModified, resultUpdate.Name);
            Assert.Equal(UserEmailModified, resultUpdate.Email);
        }
    }
}
