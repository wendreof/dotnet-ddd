using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class UserMapper : BaseTestService
    {
        [Fact(DisplayName = "It's possibile to map the models")]
        public void ItsPossibleToMapModels()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var listEntity = new List<UserEntity>();
            for (int i = 0; i < 5; i++)
            {
                listEntity.Add(new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                });
            }

            //Model => Entity
            var entity = Mapper.Map<UserEntity>(model);
            Assert.NotNull(entity);
            Assert.Equal(model.Id, entity.Id);
            Assert.Equal(model.Name, entity.Name);
            Assert.Equal(model.Email, entity.Email);
            Assert.Equal(model.CreatedAt, entity.CreatedAt);
            Assert.Equal(model.UpdatedAt, entity.UpdatedAt);

            //Entity =>  Dto
            var userDto = Mapper.Map<UserDto>(entity);
            Assert.NotNull(userDto);
            Assert.Equal(userDto.Id, entity.Id);
            Assert.Equal(userDto.Name, entity.Name);
            Assert.Equal(userDto.Email, entity.Email);
            Assert.Equal(userDto.CreatedAt, entity.CreatedAt);

            var listDto = Mapper.Map<IEnumerable<UserDto>>(listEntity);
            Assert.NotNull(listDto);
            Assert.Equal(listDto.Count(), listEntity.Count);
            Assert.Equal(listDto.First().Id, listEntity.First().Id);
            for (int i = 0; i < listDto.Count(); i++)
            {
                Assert.Equal(listDto.ElementAt(i).Id, listEntity.ElementAt(i).Id);
                Assert.Equal(listDto.ElementAt(i).Name, listEntity.ElementAt(i).Name);
                Assert.Equal(listDto.ElementAt(i).Email, listEntity.ElementAt(i).Email);
                Assert.Equal(listDto.ElementAt(i).CreatedAt, listEntity.ElementAt(i).CreatedAt);
            }

            var userDtoCreateResult = Mapper.Map<UserDtoCreateResult>(entity);
            Assert.NotNull(userDtoCreateResult);
            Assert.Equal(userDtoCreateResult.Id, entity.Id);
            Assert.Equal(userDtoCreateResult.Name, entity.Name);
            Assert.Equal(userDtoCreateResult.Email, entity.Email);
            Assert.Equal(userDtoCreateResult.CreatedAt, entity.CreatedAt);

            var userDtoUpdateResult = Mapper.Map<UserDtoUpdateResult>(entity);
            Assert.NotNull(userDtoUpdateResult);
            Assert.Equal(userDtoUpdateResult.Id, entity.Id);
            Assert.Equal(userDtoUpdateResult.Name, entity.Name);
            Assert.Equal(userDtoUpdateResult.Email, entity.Email);
            Assert.Equal(userDtoUpdateResult.UpdatedAt, entity.UpdatedAt);

            //Dto =>  Model
            var userModel = Mapper.Map<UserModel>(userDto);
            Assert.NotNull(userModel);
            Assert.Equal(userModel.Id, entity.Id);
            Assert.Equal(userModel.Name, entity.Name);
            Assert.Equal(userModel.Email, entity.Email);
            Assert.Equal(userModel.CreatedAt, entity.CreatedAt);

            var userDtoCreate = Mapper.Map<UserDtoCreate>(userModel);
            Assert.NotNull(userDtoCreate);
            Assert.Equal(userDtoCreate.Name, userModel.Name);
            Assert.Equal(userDtoCreate.Email, userModel.Email);

            var userDtoUpdate = Mapper.Map<UserDtoUpdate>(userModel);
            Assert.NotNull(userDtoUpdate);
            Assert.Equal(userDtoUpdate.Id, userModel.Id);
            Assert.Equal(userDtoUpdate.Name, userModel.Name);
            Assert.Equal(userDtoUpdate.Email, userModel.Email);
        }
    }
}
