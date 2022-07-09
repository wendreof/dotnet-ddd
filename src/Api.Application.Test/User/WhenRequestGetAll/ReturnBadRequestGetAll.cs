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
    public class ReturnBadRequestGetAll
    {
        private UsersController _controller;

        [Fact(DisplayName = "It's NOT possible to execute the method GetAll")]
        public async Task ItsNotPossibleRequestControllerGetAll()
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
            _controller.ModelState.AddModelError("Id", "Id is required");
            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
