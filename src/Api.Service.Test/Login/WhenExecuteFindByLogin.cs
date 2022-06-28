using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Login;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.Login
{
    public class WhenExecuteFindByLogin
    {
        private ILoginService _service;
        private Mock<ILoginService> _serviceMock;

        [Fact(DisplayName = "It's possible to execute the method FindByLogin")]
        public async Task ItIsPossibleToExecuteTheMethodFindByLogin()
        {
            var email = Faker.Internet.Email();
            var objRerturn = new
            {
                authenticated = true,
                createDate = DateTime.UtcNow,
                expirationDate = DateTime.UtcNow.AddHours(8),
                accessToken = Guid.NewGuid(),
                userEmail = email,
                name = Faker.Name.FullName(),
                message = "Usuário autenticado com sucesso"
            };

            var loginDto = new LoginDto
            {
                Email = email
            };

            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(x => x.FindByLogin(loginDto)).ReturnsAsync(objRerturn);
            _service = _serviceMock.Object;

            var result = await _service.FindByLogin(loginDto);
            Assert.NotNull(result);
        }
    }
}
