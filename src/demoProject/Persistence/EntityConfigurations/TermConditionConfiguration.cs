using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TermConditionConfiguration : IEntityTypeConfiguration<TermCondition>
{
    public void Configure(EntityTypeBuilder<TermCondition> builder)
    {
        builder.ToTable("TermConditions").HasKey(tc => tc.Id);

        builder.Property(tc => tc.Id).HasColumnName("Id").IsRequired();
        builder.Property(tc => tc.Header).HasColumnName("Header");
        builder.Property(tc => tc.Text).HasColumnName("Text");
        builder.Property(tc => tc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(tc => tc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(tc => tc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(tc => !tc.DeletedDate.HasValue);
    }
}