using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.WhenRequestGet
{
    public class ReturnGetAll
    {
        private UsersController _controller;

        [Fact(DisplayName = "It's possible to execute the method GetAll")]
        public async Task ItsPossibleRequestControllerGetAll()
        {
            var service = new Mock<IUserService>();

            service.Setup(x => x.GetAll()).ReturnsAsync(new List<UserDto>
            {
                new UserDto
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreatedAt = DateTime.UtcNow,
                },
                new UserDto
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreatedAt = DateTime.UtcNow,
                },
            });

            _controller = new UsersController(service.Object);
            var result = await _controller.GetAll();
            Assert.True(result is OkObjectResult);

            var resultValue = (result as OkObjectResult).Value as IEnumerable<UserDto>;
            Assert.NotNull(resultValue);
            Assert.Equal(2, resultValue.Count());
        }
    }
}
