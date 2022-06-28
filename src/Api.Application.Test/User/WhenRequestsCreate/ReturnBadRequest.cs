using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.WhenRequestsCreate
{
    public class ReturnBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "It's not possible to execute the method Create")]
        public async Task ItsNotPossibileRequestCreateController()
        {
            var service = new Mock<IUserService>();
            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            service.Setup(x => x.Post(It.IsAny<UserDtoCreate>())).ReturnsAsync(new UserDtoCreateResult
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                CreatedAt = DateTime.UtcNow
            });

            _controller = new UsersController(service.Object);
            _controller.ModelState.AddModelError("Name", "Required field");

            var url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000/api/v1/users/");
            _controller.Url = url.Object;

            var user = new UserDtoCreate
            {
                Name = name,
                Email = email
            };

            var result = await _controller.Post(user);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
