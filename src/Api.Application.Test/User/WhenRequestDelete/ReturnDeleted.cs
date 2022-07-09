using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.WhenRequestDelete
{
    public class ReturnDeleted
    {
        private UsersController _controller;

        [Fact(DisplayName = "It's possible to execute the method Delete")]
        public async Task ItsPossibileRequestUpdateController()
        {
            var service = new Mock<IUserService>();

            service.Setup(x => x.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _controller = new UsersController(service.Object);

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = (result as OkObjectResult).Value;
            Assert.NotNull(resultValue);
            Assert.True((bool)resultValue);
        }
    }
}
