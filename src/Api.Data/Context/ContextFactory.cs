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
            optionsBuilder.UseMySql("Persist Security Info=True;Server=localhost;Port=3306;Database=testedb;Uid=root;Password=WendreoFernandes!",
            optionsBuilder => optionsBuilder.EnableRetryOnFailure());
            return new MyContext(optionsBuilder.Options);
        }
    }

}
