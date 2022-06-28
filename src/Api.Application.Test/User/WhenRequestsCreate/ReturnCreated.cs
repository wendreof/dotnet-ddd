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
    public class ReturnCreated
    {
        private UsersController _controller;

        [Fact(DisplayName = "It's possible to execute the method Create")]
        public async Task ItsPossibileRequestCreateController()
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

            var url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000/api/v1/users/");
            _controller.Url = url.Object;

            var user = new UserDtoCreate
            {
                Name = name,
                Email = email
            };

            var result = await _controller.Post(user);
            Assert.True(result is CreatedResult);

            var resultValue = (result as CreatedResult).Value as UserDtoCreateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(user.Name, resultValue.Name);
            Assert.Equal(user.Email, resultValue.Email);

        }
    }
}
