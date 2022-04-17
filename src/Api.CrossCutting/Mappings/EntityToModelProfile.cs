using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
  public class EntityToModelProfile : Profile
  {
    public EntityToModelProfile()
    {
      CreateMap<UserDto, UserEntity>().ReverseMap();
      CreateMap<UserDtoCreateResult, UserEntity>().ReverseMap();
      CreateMap<UserDtoUpdateResult, UserEntity>().ReverseMap();
    }
  }
}