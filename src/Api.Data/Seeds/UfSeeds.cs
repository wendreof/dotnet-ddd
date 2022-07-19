using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Seeds
{
    public class UfSeeds
    {
        public static void Ufs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UfEntity>().HasData(
                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "AC",
                    Name = "Acre",
                    CreatedAt = DateTime.Now,
                },
                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "AL",
                    Name = "Alagoas",
                    CreatedAt = DateTime.Now,
                },
                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "AP",
                    Name = "Amapá",
                    CreatedAt = DateTime.Now,
                },
                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "AM",
                    Name = "Amazonas",
                    CreatedAt = DateTime.Now,
                },
                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "BA",
                    Name = "Bahia",
                    CreatedAt = DateTime.Now,
                },
                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "CE",
                    Name = "Ceará",
                    CreatedAt = DateTime.Now,
                },
                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "DF",
                    Name = "Distrito Federal",
                    CreatedAt = DateTime.Now,
                },
                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "ES",
                    Name = "Espírito Santo",

                    CreatedAt = DateTime.Now,
                },
                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "GO",
                    Name = "Goiás",
                    CreatedAt = DateTime.Now,
                },
                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "MA",
                    Name = "Maranhão",
                    CreatedAt = DateTime.Now,
                },
                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "MT",
                    Name = "Mato Grosso",
                    CreatedAt = DateTime.Now,
                },
                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "MS",
                    Name = "Mato Grosso do Sul",
                    CreatedAt = DateTime.Now,
                },
                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "MG",
                    Name = "Minas Gerais",
                    CreatedAt = DateTime.Now,
                },
                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "PA",
                    Name = "Pará",
                    CreatedAt = DateTime.Now,
                },
                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "PB",
                    Name = "Paraíba",
                    CreatedAt = DateTime.Now,
                },
                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "PR",
                    Name = "Paraná",
                    CreatedAt = DateTime.Now,
                },

                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "PE",
                    Name = "Pernambuco",
                    CreatedAt = DateTime.Now,
                },
                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "PI",
                    Name = "Piauí",
                    CreatedAt = DateTime.Now,
                },
                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "RJ",
                    Name = "Rio de Janeiro",
                    CreatedAt = DateTime.Now,
                },
                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "RN",
                    Name = "Rio Grande do Norte",
                    CreatedAt = DateTime.Now,
                },
                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "RS",
                    Name = "Rio Grande do Sul",
                    CreatedAt = DateTime.Now,
                },
                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "RO",
                    Name = "Rondônia",
                    CreatedAt = DateTime.Now,
                },
                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "RR",
                    Name = "Roraima",
                    CreatedAt = DateTime.Now,
                },
                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "SC",
                    Name = "Santa Catarina",
                    CreatedAt = DateTime.Now,
                },
                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "SP",
                    Name = "São Paulo",
                    CreatedAt = DateTime.Now,
                },
                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "SE",
                    Name = "Sergipe",
                    CreatedAt = DateTime.Now,
                },

                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "TO",
                    Name = "Tocantins",
                    CreatedAt = DateTime.Now,
                },
                new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Sigla = "ES",
                    Name = "Espírito Santo",
                    CreatedAt = DateTime.Now,
                });
        }
    }
}
