using System;
using System.Threading.Tasks;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class CityImplementation : BaseRepository<CityEntity>, ICityRepository
    {
        private readonly DbSet<CityEntity> _dataSet;
        public CityImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<CityEntity>();
        }

        public async Task<CityEntity> GetCompleteByIbge(int ibgeCode)
        {
            return await _dataSet.Include(x => x.Uf).FirstOrDefaultAsync(x => x.CodIbge.Equals(ibgeCode));
        }

        public async Task<CityEntity> GetCompleteById(Guid id)
        {
            return await _dataSet.Include(x => x.Uf).FirstOrDefaultAsync(x => x.CodIbge.Equals(id));
        }
    }
}
