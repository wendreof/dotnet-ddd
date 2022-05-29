using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {

        }
    }

    public class DbTeste : IDisposable
    {
        private readonly string dataBaseName = $"dbApiTeste_{Guid.NewGuid().ToString().Replace("-", "")}";
        public ServiceProvider ServiceProvider { get; private set; }

        public DbTeste()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<MyContext>(
                options => options.UseMySql($"Persist Security Info=True;Server=localhost;Port=3306;Database={dataBaseName};Uid=root;Password=WendreoFernandes!"),
                  ServiceLifetime.Transient);

            ServiceProvider = serviceCollection.BuildServiceProvider();
            using var context = ServiceProvider.GetService<MyContext>();
            context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            using var context = ServiceProvider.GetService<MyContext>();
            context.Database.EnsureDeleted();
        }
    }
}
