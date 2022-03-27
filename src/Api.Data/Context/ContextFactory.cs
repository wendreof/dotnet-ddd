using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Api.Data.Context
{
  public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
  {
    private readonly IConfigurationRoot _configuration;
    public MyContext CreateDbContext(string[] args)
    {
      var connectionString = _configuration.GetConnectionString("DefaultConnection");
      //var connectionString = "Server=localhost;Port=3306;Database=testedb;Uid=root;Password=WendreoFernandes!";
      var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
      optionsBuilder.UseMySql(connectionString);
      return new MyContext(optionsBuilder.Options);
    }
  }

}
