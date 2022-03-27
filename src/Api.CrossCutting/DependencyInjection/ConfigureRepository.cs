using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;
using Api.Service.Services;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
  public class ConfigureRepository
  {
    public IConfiguration Configuration { get; }
    public static void ConfigureDependencyRepository(IServiceCollection serviceCollection)
    {
      serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

      serviceCollection.AddDbContext<MyContext>(options =>
      {
        options.UseMySql("Server=localhost;Port=3306;Database=testedb;Uid=root;Password=WendreoFernandes!");
      });
    }
  }
}