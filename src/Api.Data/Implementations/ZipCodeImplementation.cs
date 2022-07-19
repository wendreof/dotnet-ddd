using System.Threading.Tasks;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class ZipCodeImplementation : BaseRepository<ZipCodeEntity>, IZipCodeRepository
    {
        private readonly DbSet<ZipCodeEntity> _dataSet;
        public ZipCodeImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<ZipCodeEntity>();
        }

        public async Task<ZipCodeEntity> SelectAsync(string zipCode)
        {
            return await _dataSet.Include(x => x.City)
            .ThenInclude(x => x.Uf)
            .SingleOrDefaultAsync(x => x.ZipCode.Equals(zipCode));
        }
    }
}
