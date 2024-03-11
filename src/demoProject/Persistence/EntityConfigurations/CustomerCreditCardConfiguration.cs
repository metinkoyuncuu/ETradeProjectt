using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerCreditCardConfiguration : IEntityTypeConfiguration<CustomerCreditCard>
{
    public void Configure(EntityTypeBuilder<CustomerCreditCard> builder)
    {
        builder.ToTable("CustomerCreditCards").HasKey(ccc => ccc.Id);

        builder.Property(ccc => ccc.Id).HasColumnName("Id").IsRequired();
        builder.Property(ccc => ccc.CustomerId).HasColumnName("CustomerId");
        builder.Property(ccc => ccc.CardType).HasColumnName("CardType");
        builder.Property(ccc => ccc.HolderName).HasColumnName("HolderName");
        builder.Property(ccc => ccc.ExpireMonth).HasColumnName("ExpireMonth");
        builder.Property(ccc => ccc.ExpireYear).HasColumnName("ExpireYear");
        builder.Property(ccc => ccc.CVV).HasColumnName("CVV");
        builder.Property(ccc => ccc.CardNumber).HasColumnName("CardNumber");
        builder.Property(ccc => ccc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ccc => ccc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ccc => ccc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ccc => !ccc.DeletedDate.HasValue);
    }
}