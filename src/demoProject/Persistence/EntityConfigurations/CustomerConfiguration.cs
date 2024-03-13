using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace Persistence.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.PhoneNumber).HasColumnName("PhoneNumber");
        builder.Property(c => c.Balance).HasColumnName("Balance");
        builder.Property(c => c.BirthDate).HasColumnName("BirthDate");
        builder.Property(c => c.ImageId).HasColumnName("ImageId");
        builder.Property(c => c.GenderId).HasColumnName("GenderId");
        builder.Property(c => c.UserId).HasColumnName("UserId");
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");
        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
        builder.HasData(getSeeds());
    }

    
        private IEnumerable<Customer> getSeeds()
            {
                List<Customer> customers = new() {
                new() {
                    Id = 1,
                    PhoneNumber = "+905555555555",
                    Balance = 15.4F,
                    BirthDate = new DateTime(2002, 10, 25),
                    ImageId = 1,
                    GenderId = 2,
                    UserId = 3,
                }
            };

                return customers.ToArray();
         }
}