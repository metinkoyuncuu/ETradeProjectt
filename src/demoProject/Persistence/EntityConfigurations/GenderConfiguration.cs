using Core.Security.Entities;
using Core.Security.Hashing;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class GenderConfiguration : IEntityTypeConfiguration<Gender>
{
    public void Configure(EntityTypeBuilder<Gender> builder)
    {
        builder.ToTable("Genders").HasKey(g => g.Id);

        builder.Property(g => g.Id).HasColumnName("Id").IsRequired();
        builder.Property(g => g.Name).HasColumnName("Name");
        builder.Property(g => g.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(g => g.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(g => g.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(g => !g.DeletedDate.HasValue);
        builder.HasData(getSeeds());
    }
    private IEnumerable<Gender> getSeeds()
    {
        List<Gender> genders = new() { new() {Id=1, Name = "Man" }, new() {Id=2,Name="Woman"} };
         
        return genders.ToArray();
    }
}