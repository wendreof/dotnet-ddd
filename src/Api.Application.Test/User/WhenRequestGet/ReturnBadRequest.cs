using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.WhenRequestGet
{
    public class ReturnBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "It's NOT possible to execute the method Get")]
        public async Task ItsNotPossibleRequestControllerGet()
        {
            var service = new Mock<IUserService>();
            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            service.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(new UserDto
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                CreatedAt = DateTime.UtcNow,
            });

            _controller = new UsersController(service.Object);
            _controller.ModelState.AddModelError("Id", "Id is required");

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
