using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SizeConfiguration : IEntityTypeConfiguration<Size>
{
    public void Configure(EntityTypeBuilder<Size> builder)
    {
        builder.ToTable("Sizes").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.Name).HasColumnName("Name");
        builder.Property(s => s.IsVerified).HasColumnName("IsVerified");
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
        builder.HasData(getSeeds());
    }
    private IEnumerable<Size> getSeeds()
    {
        List<Size> sizes = new() {
            new() { Id = 1, Name = "XS", IsVerified = true, },
            new() { Id = 2, Name = "S", IsVerified = true,},
            new() { Id = 3, Name = "M", IsVerified = true},
            new() { Id = 4, Name = "L", IsVerified = true},
            new() { Id = 5, Name = "XL", IsVerified = true},
            new() { Id = 6, Name = "XXL", IsVerified = true }
    };

        return sizes.ToArray();
    }

}