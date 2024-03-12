using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder.ToTable("Colors").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Name");
        builder.Property(c => c.IsVerified).HasColumnName("IsVerified");
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
        builder.HasData(getSeeds());
    }
    private IEnumerable<Color> getSeeds()
    {
        List<Color> colors = new() {
            new() { Id = 1, Name = "Red", IsVerified = true },
            new() { Id = 2, Name = "Yellow", IsVerified = true },
            new() { Id = 3, Name = "Blue", IsVerified = true },
            new() { Id = 4, Name = "Green", IsVerified = true },
            new() { Id = 5, Name = "Orange", IsVerified = true },
            new() { Id = 6, Name = "Purple", IsVerified = true },
            new() { Id = 7, Name = "Pink", IsVerified = true },
            new() { Id = 8, Name = "Cyan", IsVerified = true },
            new() { Id = 9, Name = "Magenta", IsVerified = true },
            new() { Id = 10, Name = "Brown", IsVerified = true },
            new() { Id = 11, Name = "White", IsVerified = true },
            new() { Id = 12, Name = "Black", IsVerified = true },
            new() { Id = 13, Name = "Gray", IsVerified = true },
            new() { Id = 14, Name = "Beige", IsVerified = true },
            new() { Id = 15, Name = "Turquoise", IsVerified = true }
        };


        return colors.ToArray();
    }
}