using System;
using System.Linq;
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

      #region Create
      var _createdRegistry = await _repository.InsertAsync(_entity);
      Assert.NotNull(_createdRegistry);
      Assert.Equal(_entity.Email, _createdRegistry.Email);
      Assert.Equal(_entity.Name, _createdRegistry.Name);
      Assert.False(_createdRegistry.Id == Guid.Empty);
      #endregion

      #region Update
      _entity.Name = Faker.Name.First();
      var _updatedRegistry = await _repository.UpdateAsync(_entity);
      Assert.NotNull(_updatedRegistry);
      Assert.Equal(_entity.Email, _updatedRegistry.Email);
      Assert.Equal(_entity.Name, _updatedRegistry.Name);
      #endregion

      #region Read
      var _registryExists = await _repository.ExistAsync(_updatedRegistry.Id);
      Assert.True(_registryExists);

      var _selectedRegistry = await _repository.SelectAsync(_updatedRegistry.Id);
      Assert.NotNull(_selectedRegistry);
      Assert.Equal(_entity.Email, _selectedRegistry.Email);
      Assert.Equal(_entity.Name, _selectedRegistry.Name);

      var _allRegistries = await _repository.SelectAsync();
      Assert.NotNull(_allRegistries);
      Assert.True(_allRegistries.Count() > 0);
      #endregion

      #region Delete  
      var _deletedRegistry = await _repository.DeleteAsync(_updatedRegistry.Id);
      Assert.True(_deletedRegistry);
      #endregion

      var _defaultRegistry = await _repository.FindByLogin("wendreadm@gmail.com");
      Assert.NotNull(_defaultRegistry);
      Assert.Equal("wendreadm@gmail.com", _defaultRegistry.Email);
      Assert.Equal("Administrator", _defaultRegistry.Name);

    }
  }

}