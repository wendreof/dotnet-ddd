using System;
using System.Collections.Generic;
using Api.Domain.Dtos.User;

namespace Api.Service.Test.User
{
  public class UserTests
  {
    public static string UserName { get; set; }
    public static string UserEmail { get; set; }
    public static string UserNameModified { get; set; }
    public static string UserEmailModified { get; set; }
    public static Guid UserId { get; set; }
    public List<UserDto> listUserDto = new List<UserDto>();
    public UserDto userDto;
    public UserDtoCreate userDtoCreate;
    public UserDtoCreateResult userDtoCreateResult;
    public UserDtoUpdate userDtoUpdate;
    public UserDtoUpdateResult userDtoUpdateResult;
    public UserTests()
    {
      UserId = Guid.NewGuid();
      UserName = Faker.Name.FullName();
      UserNameModified = Faker.Name.FullName();
      UserEmail = Faker.Internet.Email();
      UserEmailModified = Faker.Internet.Email();

      for (var i = 0; i < 10; i++)
      {
        listUserDto.Add(new UserDto
        {
          Id = Guid.NewGuid(),
          Name = Faker.Name.FullName(),
          Email = Faker.Internet.Email()
        });
      }

      userDto = new UserDto
      {
        Id = UserId,
        Name = UserName,
        Email = UserEmail
      };

      userDtoCreate = new UserDtoCreate
      {
        Name = UserName,
        Email = UserEmail
      };

      userDtoUpdate = new UserDtoUpdate
      {
        Id = UserId,
        Name = UserNameModified,
        Email = UserEmailModified
      };

      userDtoCreateResult = new UserDtoCreateResult
      {
        Id = UserId,
        Name = UserName,
        Email = UserEmail,
        CreatedAt = DateTime.UtcNow
      };

      userDtoUpdateResult = new UserDtoUpdateResult
      {
        Id = UserId,
        Name = UserNameModified,
        Email = UserEmailModified,
        UpdatedAt = DateTime.UtcNow
      };

    }

  }
}