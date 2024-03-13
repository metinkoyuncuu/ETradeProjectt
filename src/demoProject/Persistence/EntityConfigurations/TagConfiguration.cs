using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tags").HasKey(t => t.Id);

        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
        builder.Property(t => t.Name).HasColumnName("Name");
        builder.Property(t => t.IsVerified).HasColumnName("IsVerified");
        builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(t => !t.DeletedDate.HasValue);
        builder.HasData(getSeeds());
    }
    private IEnumerable<Tag> getSeeds()
    {
        List<Tag> tags = new() {
        new() { Id = 1, Name = "Tag1", IsVerified = true },
        new() { Id = 2, Name = "Tag2", IsVerified = true },
        new() { Id = 3, Name = "Tag3", IsVerified = true },
        new() { Id = 4, Name = "Tag4", IsVerified = false}
    };

        return tags.ToArray();
    }
}