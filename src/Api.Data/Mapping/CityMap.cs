using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class CityMap : IEntityTypeConfiguration<CityEntity>
    {
        public void Configure(EntityTypeBuilder<CityEntity> builder)
        {
            builder.ToTable("City");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.CodIbge);
            builder.HasOne(x => x.Uf).WithMany(c => c.Cities);
        }
    }
}
