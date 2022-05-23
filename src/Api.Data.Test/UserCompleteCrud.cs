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
    private ServiceProvider ServiceProvider { get; set; }

    public UserCompleteCrud(DbTeste dbTeste)
    {
      ServiceProvider = dbTeste.ServiceProvider;
    }

    [Fact(DisplayName = "User Crud")]
    [Trait("CRUD", "UserEntity")]
    public async Task Is_Possible_Realize_User_Crud()
    {
      using var context = ServiceProvider.GetService<MyContext>();

      UserImplementation _repository = new UserImplementation(context);

      UserEntity _entity = new UserEntity
      {
        Email = Faker.Internet.Email(),
        Name = Faker.Name.FullName(),
      };

      var _createdRegistry = await _repository.InsertAsync(_entity);
      Assert.NotNull(_createdRegistry);
      Assert.Equal(_entity.Email, _createdRegistry.Email);
      Assert.Equal(_entity.Name, _createdRegistry.Name);
      Assert.False(_createdRegistry.Id == Guid.Empty);
    }
  }

}