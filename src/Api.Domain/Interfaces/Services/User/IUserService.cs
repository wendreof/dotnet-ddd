using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.User
{
  public interface IUserService
  {
    Task<UserEntity> Get(Guid id);
    Task<IEnumerable<UserEntity>> GetAll();
    Task<UserEntity> Post(UserEntity userEntity);
    Task<UserEntity> Put(UserEntity userEntity);
    Task<bool> Delete(Guid id);
  }
}