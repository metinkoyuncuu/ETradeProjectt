using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
{
    public void Configure(EntityTypeBuilder<CustomerAddress> builder)
    {
        builder.ToTable("CustomerAddresses").HasKey(ca => ca.Id);

        builder.Property(ca => ca.Id).HasColumnName("Id").IsRequired();
        builder.Property(ca => ca.CustomerId).HasColumnName("CustomerId");
        builder.Property(ca => ca.Header).HasColumnName("Header");
        builder.Property(ca => ca.FirstName).HasColumnName("FirstName");
        builder.Property(ca => ca.LastName).HasColumnName("LastName");
        builder.Property(ca => ca.PhoneNumber).HasColumnName("PhoneNumber");
        builder.Property(ca => ca.CityId).HasColumnName("CityId");
        builder.Property(ca => ca.DistrictId).HasColumnName("DistrictId");
        builder.Property(ca => ca.Address).HasColumnName("Address");
        builder.Property(ca => ca.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ca => ca.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ca => ca.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ca => !ca.DeletedDate.HasValue);
    }
}