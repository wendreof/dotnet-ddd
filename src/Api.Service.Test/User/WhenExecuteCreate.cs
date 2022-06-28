using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
    public class WhenExecuteCreate : UserTests
    {
        private IUserService _userService;
        private Mock<IUserService> _userServiceMock;

        [Fact(DisplayName = "It's possibile execute Create method")]
        public async void ItsPossibleExecuteCreateMethod()
        {
            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(x => x.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
            _userService = _userServiceMock.Object;

            var _result = await _userService.Post(userDtoCreate);
            Assert.NotNull(_result);
            Assert.Equal(userDtoCreateResult.Name, _result.Name);
            Assert.Equal(userDtoCreateResult.Email, _result.Email);
        }
    }
}
