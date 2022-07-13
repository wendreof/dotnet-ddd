using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ZipCodeMap : IEntityTypeConfiguration<ZipCodeEntity>
    {
        public void Configure(EntityTypeBuilder<ZipCodeEntity> builder)
        {
            builder.ToTable("ZipCode");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.ZipCode);
            builder.HasOne(x => x.City).WithMany(z => z.ZipCodes);
        }
    }
}
