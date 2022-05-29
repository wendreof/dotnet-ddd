using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Dtos.Login;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Repository;
using Api.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _repository;

        private readonly SigningConfigurations _signingConfiguration;
        private readonly TokenConfigurations _tokenConfiguration;

        private IConfiguration Configuration { get; }

        public LoginService(IUserRepository repository,
        SigningConfigurations signingConfiguration,
        TokenConfigurations tokenConfiguration,
        IConfiguration configuration)

        {
            _repository = repository;
            _signingConfiguration = signingConfiguration;
            _tokenConfiguration = tokenConfiguration;
            Configuration = configuration;
        }

        public async Task<object> FindByLogin(LoginDto userEntity)
        {
            if (userEntity != null && !string.IsNullOrEmpty(userEntity.Email))
            {
                var baseUser = await _repository.FindByLogin(userEntity.Email);

                if (baseUser == null)
                {
                    return new
                    {
                        authenticaded = false,
                        message = "Falha ao autentincar"
                    };
                }
                else
                {
                    var identity = new ClaimsIdentity(
                      new GenericIdentity(userEntity.Email),
                      new[]
                      {
              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
              new Claim(JwtRegisteredClaimNames.UniqueName, userEntity.Email),
                  });

                    DateTime createDate = DateTime.Now;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

                    var handler = new JwtSecurityTokenHandler();
                    var token = CreateToken(identity, createDate, expirationDate, handler);

                    return SuccessObject(createDate, expirationDate, token, baseUser);
                }
            }
            else
            {
                return new
                {
                    authenticaded = false,
                    message = "Falha ao autentincar"
                };
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfiguration.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            return handler.WriteToken(securityToken);
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, UserEntity userEntity)
        {
            return new
            {
                authenticated = true,
                createDate = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expirationDate = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                userEmail = userEntity.Email,
                name = userEntity.Name,
                message = "Usuário autenticado com sucesso"
            };
        }
    }
}
