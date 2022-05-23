using System;
using System.Threading.Tasks;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Data.Context;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
  public class UserCompleteCrud : BaseTest, IClassFixture<DbTeste>
  {
    private ServiceProvider _serviceProvider { get; set; }

    public UserCompleteCrud(DbTeste dbTeste)
    {
      _serviceProvider = dbTeste.ServiceProvider;
    }

    [Fact(DisplayName = "User Crud")]
    [Trait("CRUD", "UserEntity")]
    public async Task Is_Possible_Realize_User_Crud()
    {
      using var context = _serviceProvider.GetService<MyContext>();

      UserImplementation _repository = new UserImplementation(context);

      UserEntity _entity = new UserEntity
      {
        Email = "teste@mail.com",
        Name = "Teste"
      };

      var _createdRegistry = await _repository.InsertAsync(_entity);
      Assert.NotNull(_createdRegistry);
      Assert.Equal("teste@mail.com", _createdRegistry.Email);
      Assert.Equal("Teste", _createdRegistry.Name);
      Assert.False(_createdRegistry.Id == Guid.Empty);
    }
  }

}