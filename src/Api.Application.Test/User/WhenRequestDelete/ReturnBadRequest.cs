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
    public class ReturnBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "It's not possible to execute the method Update")]
        public async Task ItsNotPossibileRequestUpdateController()
        {
            var service = new Mock<IUserService>();

            service.Setup(x => x.Delete(It.IsAny<Guid>())).ReturnsAsync(false);

            _controller = new UsersController(service.Object);
            _controller.ModelState.AddModelError("Id", "Invalid format");

            var result = await _controller.Delete(default);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}
