using Api.Domain.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseMySql(Settings.ConnectionString, optionsBuilder => optionsBuilder.EnableRetryOnFailure());

            return new MyContext(optionsBuilder.Options);
        }
    }

}
