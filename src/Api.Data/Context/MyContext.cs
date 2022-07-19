using System;
using Api.Data.Mapping;
using Api.Data.Seeds;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>(new UserMap().Configure);

            modelBuilder.Entity<UfEntity>(new UfMap().Configure);
            modelBuilder.Entity<CityEntity>(new CityMap().Configure);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<ZipCodeEntity>(new ZipCodeMap().Configure);

            modelBuilder.Entity<UserEntity>().HasData(
              new UserEntity
              {
                  Id = Guid.NewGuid(),
                  Name = "Administrator",
                  Email = "wendreadm@gmail.com",
                  CreatedAt = DateTime.Now,
                  UpdatedAt = DateTime.Now,
              });

            UfSeeds.Ufs(modelBuilder);
        }
    }
}
