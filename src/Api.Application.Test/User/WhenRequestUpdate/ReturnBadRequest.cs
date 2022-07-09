using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.WhenRequestUpdate
{
    public class ReturnBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "It's not possible to execute the method Update")]
        public async Task ItsNotPossibileRequestUpdateController()
        {
            var service = new Mock<IUserService>();
            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            service.Setup(x => x.Put(It.IsAny<UserDtoUpdate>())).ReturnsAsync(new UserDtoUpdateResult
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                UpdatedAt = DateTime.UtcNow
            });

            _controller = new UsersController(service.Object);
            _controller.ModelState.AddModelError("E-mail", "E-mail is required");

            var userDtoUpdate = new UserDtoUpdate
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email
            };

            var result = await _controller.Put(userDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}
