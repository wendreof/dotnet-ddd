using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Repository;

namespace Api.Service.Services
{
  public class LoginService : ILoginService
  {
    private readonly IUserRepository _repository;

    public LoginService(IUserRepository repository)
    {
      _repository = repository;
    }

    public async Task<object> FindByLogin(UserEntity userEntity)
    {
      if (userEntity != null && !string.IsNullOrEmpty(userEntity.Email))
      {
        return await _repository.FindByLogin(userEntity.Email);
      }
      else
      {
        return null;
      }
    }
  }
}