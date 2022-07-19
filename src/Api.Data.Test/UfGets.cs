using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Implementations;
using Data.Context;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class UfGets : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider ServiceProvider { get; set; }
        public UfGets(DbTeste dbTeste)
        {
            ServiceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "Uf Gets")]
        [Trait("Gets", "UfEntity")]
        public async Task ItsPossibileToGetAllUfs()
        {
            using var context = ServiceProvider.GetService<MyContext>();

            var repository = new UfImplementation(context);
            var allUfs = await repository.SelectAsync();
            Assert.NotNull(allUfs);
            Assert.True(allUfs.Count() > 0);
            Assert.True(allUfs.Count() == 27);

            var uf = await repository.SelectAsync(new Guid());
            Assert.Null(uf);
            Assert.False(uf.Id == Guid.Empty);
        }
    }
}
