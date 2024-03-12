using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DistrictConfiguration : IEntityTypeConfiguration<District>
{
    public void Configure(EntityTypeBuilder<District> builder)
    {
        builder.ToTable("Districts").HasKey(d => d.Id);

        builder.Property(d => d.Id).HasColumnName("Id").IsRequired();
        builder.Property(d => d.Name).HasColumnName("Name");
        builder.Property(d => d.CityId).HasColumnName("CityId");
        builder.Property(d => d.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(d => d.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(d => d.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(d => !d.DeletedDate.HasValue);
        builder.HasData(getSeeds());
    }
    private IEnumerable<District> getSeeds()
    {
        List<District> districts = new() {
            new() { Id = 1, Name = "DemoDistrictForCity1",CityId=1},
            new() { Id = 2, Name = "DemoDistrictForCity2" ,CityId=2} };

        return districts.ToArray();
    }
}