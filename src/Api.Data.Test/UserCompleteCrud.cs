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

            var repository = new UserImplementation(context);

            var entity = new UserEntity
            {
                Email = Faker.Internet.Email(),
                Name = Faker.Name.FullName(),
            };

            #region Create
            var createdRegistry = await repository.InsertAsync(entity);
            Assert.NotNull(createdRegistry);
            Assert.Equal(entity.Email, createdRegistry.Email);
            Assert.Equal(entity.Name, createdRegistry.Name);
            Assert.False(createdRegistry.Id == Guid.Empty);
            #endregion

            #region Update
            entity.Name = Faker.Name.First();
            var updatedRegistry = await repository.UpdateAsync(entity);
            Assert.NotNull(updatedRegistry);
            Assert.Equal(entity.Email, updatedRegistry.Email);
            Assert.Equal(entity.Name, updatedRegistry.Name);
            #endregion

            #region Read
            var registryExists = await repository.ExistAsync(updatedRegistry.Id);
            Assert.True(registryExists);

            var selectedRegistry = await repository.SelectAsync(updatedRegistry.Id);
            Assert.NotNull(selectedRegistry);
            Assert.Equal(entity.Email, selectedRegistry.Email);
            Assert.Equal(entity.Name, selectedRegistry.Name);

            var allRegistries = await repository.SelectAsync();
            Assert.NotNull(allRegistries);
            Assert.True(allRegistries.Count() > 0);
            #endregion

            #region Delete  
            var deletedRegistry = await repository.DeleteAsync(updatedRegistry.Id);
            Assert.True(deletedRegistry);
            #endregion

            var defaultRegistry = await repository.FindByLogin("wendreadm@gmail.com");
            Assert.NotNull(defaultRegistry);
            Assert.Equal("wendreadm@gmail.com", defaultRegistry.Email);
            Assert.Equal("Administrator", defaultRegistry.Name);

        }
    }

}
