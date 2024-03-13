using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("Brands").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Name).HasColumnName("Name");
        builder.Property(b => b.IsVerified).HasColumnName("IsVerified");
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        builder.HasData(getSeeds());
    }
    private IEnumerable<Brand> getSeeds()
    {
        List<Brand> brands = new() {
            new() { Id = 1, Name = "DemoBrand1",IsVerified=true }, 
            new() { Id = 2, Name = "DemoBrand2" ,IsVerified=true} };

        return brands.ToArray();
    }
}