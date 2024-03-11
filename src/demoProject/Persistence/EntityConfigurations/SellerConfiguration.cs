using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SellerConfiguration : IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> builder)
    {
        builder.ToTable("Sellers").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.UserId).HasColumnName("UserId");
        builder.Property(s => s.PersonalAddress).HasColumnName("PersonalAddress");
        builder.Property(s => s.Country).HasColumnName("Country");
        builder.Property(s => s.PhoneNumber).HasColumnName("PhoneNumber");
        builder.Property(s => s.IdentityNumber).HasColumnName("IdentityNumber");
        builder.Property(s => s.ImageId).HasColumnName("ImageId");
        builder.Property(s => s.IsVerified).HasColumnName("IsVerified");
        builder.Property(s => s.BirthDate).HasColumnName("BirthDate");
        builder.Property(s => s.GenderId).HasColumnName("GenderId");
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
    }
}