using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class UfMap : IEntityTypeConfiguration<UfEntity>
    {
        public void Configure(EntityTypeBuilder<UfEntity> builder)
        {
            builder.ToTable("Uf");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Sigla).IsUnique();
            builder.Property(x => x.Sigla).HasColumnName("Sigla");
            builder.Property(x => x.Name).HasColumnName("Name");
        }
    }
}
