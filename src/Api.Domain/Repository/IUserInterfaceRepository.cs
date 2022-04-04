using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
  public interface IUserInterfaceRepository : IRepository<UserEntity>
  {
    Task<UserEntity> FindByLogin(string email);
  }
}