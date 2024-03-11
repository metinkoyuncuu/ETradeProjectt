using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BillConfiguration : IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        builder.ToTable("Bills").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.OrderId).HasColumnName("OrderId");
        builder.Property(b => b.Header).HasColumnName("Header");
        builder.Property(b => b.FirstName).HasColumnName("FirstName");
        builder.Property(b => b.LastName).HasColumnName("LastName");
        builder.Property(b => b.PhoneNumber).HasColumnName("PhoneNumber");
        builder.Property(b => b.Address).HasColumnName("Address");
        builder.Property(b => b.CityId).HasColumnName("CityId");
        builder.Property(b => b.DistrictId).HasColumnName("DistrictId");
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}