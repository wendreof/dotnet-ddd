using System;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
    public class WhenExecuteDelete : UserTests
    {
        private IUserService _userService;
        private Mock<IUserService> _userServiceMock;

        [Fact(DisplayName = "It's possibile execute Delete method")]
        public async void ItsPossibleExecuteDeleteMethod()
        {
            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(x => x.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _userService = _userServiceMock.Object;

            var _result = await _userService.Delete(UserId);
            Assert.True(_result);
        }
    }
}
