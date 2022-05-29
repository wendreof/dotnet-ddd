using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
    public class WhenExecuteGetAll : UserTests
    {
        private IUserService _userService;
        private Mock<IUserService> _userServiceMock;

        [Fact(DisplayName = "It's possibile execute GetAll method")]
        public async void ItsPossibleExecuteGetAllMethod()
        {
            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(x => x.GetAll()).ReturnsAsync(listUserDto);
            _userService = _userServiceMock.Object;

            var result = await _userService.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<UserDto>();
            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(x => x.GetAll()).ReturnsAsync(_listResult.AsEnumerable());
            _userService = _userServiceMock.Object;

            var _resultEmpty = await _userService.GetAll();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);
        }
    }
}