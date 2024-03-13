using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Name");
        builder.Property(c => c.IsVerified).HasColumnName("IsVerified");
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
        builder.HasData(getSeeds());
    }
    private IEnumerable<Category> getSeeds()
    {
        List<Category> categories = new() {
            new() { Id = 1, Name = "DemoCategory1",IsVerified=true },
            new() { Id = 2, Name = "DemoCategory2" ,IsVerified=true} };

        return categories.ToArray();
    }
}