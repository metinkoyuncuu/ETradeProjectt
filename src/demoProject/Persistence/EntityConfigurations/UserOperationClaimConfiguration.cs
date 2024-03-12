using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
{
    public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
    {
        builder.ToTable("UserOperationClaims").HasKey(uoc => uoc.Id);

        builder.Property(uoc => uoc.Id).HasColumnName("Id").IsRequired();
        builder.Property(uoc => uoc.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(uoc => uoc.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();
        builder.Property(uoc => uoc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(uoc => uoc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(uoc => uoc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(uoc => !uoc.DeletedDate.HasValue);

        builder.HasOne(uoc => uoc.User);
        builder.HasOne(uoc => uoc.OperationClaim);

        builder.HasData(getSeeds());
    }

    private IEnumerable<UserOperationClaim> getSeeds()
    {

        UserOperationClaim adminUserOperationClaim = new(id: 1, userId: 1, operationClaimId: 1);

        UserOperationClaim sellerUserOperationClaim = new(id: 2, userId: 2, operationClaimId: 2);

        UserOperationClaim sellerCustomerUserOperationClaim = new(id: 3, userId: 2, operationClaimId: 3);

        UserOperationClaim customerUserOperationClaim = new(id: 4, userId: 3, operationClaimId: 3);

        List<UserOperationClaim> userOperationClaims = new() { adminUserOperationClaim, sellerUserOperationClaim,
            sellerCustomerUserOperationClaim, customerUserOperationClaim};

        return userOperationClaims;
    }
}
