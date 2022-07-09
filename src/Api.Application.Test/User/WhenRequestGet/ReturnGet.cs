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
    public class ReturnGet
    {
        private UsersController _controller;

        [Fact(DisplayName = "It's possible to execute the method Get")]
        public async Task ItsPossibleRequestControllerGet()
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
            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = (result as OkObjectResult).Value as UserDto;
            Assert.NotNull(resultValue);
            Assert.Equal(name, resultValue.Name);
            Assert.Equal(email, resultValue.Email);
        }
    }
}
