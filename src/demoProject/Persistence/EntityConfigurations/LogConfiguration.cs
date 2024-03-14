using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LogConfiguration : IEntityTypeConfiguration<Log>
{
    public void Configure(EntityTypeBuilder<Log> builder)
    {
        builder.ToTable("Logs").HasKey(l => l.Id);

        builder.Property(l => l.Id).HasColumnName("Id").IsRequired();
        builder.Property(l => l.FullName).HasColumnName("FullName");
        builder.Property(l => l.UserId).HasColumnName("UserId");
        builder.Property(l => l.Operation).HasColumnName("Operation");
        builder.Property(l => l.MethodName).HasColumnName("MethodName");
        builder.Property(l => l.Data).HasColumnName("Data");
        builder.Property(l => l.IsReaded).HasColumnName("IsReaded");
        builder.Property(l => l.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(l => l.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(l => l.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(l => !l.DeletedDate.HasValue);
    }
}