using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace Api.Data.Context
{
  public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
  {
    //private readonly IConfigurationRoot _configuration;
    public MyContext CreateDbContext(string[] args)
    {
      //var connectionString = _configuration.GetConnectionString("DefaultConnection");
      var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");
      var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
      optionsBuilder.UseMySql(connectionString);
      return new MyContext(optionsBuilder.Options);
    }
  }

}
