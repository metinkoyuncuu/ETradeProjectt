using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
{
    public void Configure(EntityTypeBuilder<SubCategory> builder)
    {
        builder.ToTable("SubCategories").HasKey(sc => sc.Id);

        builder.Property(sc => sc.Id).HasColumnName("Id").IsRequired();
        builder.Property(sc => sc.Name).HasColumnName("Name");
        builder.Property(sc => sc.CategoryId).HasColumnName("CategoryId");
        builder.Property(sc => sc.IsVerified).HasColumnName("IsVerified");
        builder.Property(sc => sc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sc => sc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sc => sc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(sc => !sc.DeletedDate.HasValue);
        builder.HasData(getSeeds());
    }
    private IEnumerable<SubCategory> getSeeds()
    {
        List<SubCategory> subCategories = new() {
        new() { Id = 1, Name = "SubCategory1", CategoryId = 1, IsVerified = true },
        new() { Id = 2, Name = "SubCategory2", CategoryId = 1, IsVerified = true },
        new() { Id = 3, Name = "SubCategory3", CategoryId = 2, IsVerified = true },
        new() { Id = 4, Name = "SubCategory4", CategoryId = 2, IsVerified = true}
    };

        return subCategories.ToArray();
    }

}