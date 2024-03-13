using Core.Security.Entities;
using Core.Security.Hashing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(u => u.Id);

        builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
        builder.Property(u => u.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(u => u.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(u => u.Email).HasColumnName("Email").IsRequired();
        builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
        builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired();
        builder.Property(u => u.Status).HasColumnName("Status").HasDefaultValue(true);
        builder.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatorType").IsRequired();
        builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(u => u.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

        builder.HasMany(u => u.UserOperationClaims);
        builder.HasMany(u => u.RefreshTokens);
        builder.HasMany(u => u.EmailAuthenticators);
        builder.HasMany(u => u.OtpAuthenticators);

        builder.HasData(getSeeds());
    }

    private IEnumerable<User> getSeeds()
    {

        HashingHelper.CreatePasswordHash(
            password: "adminpassw",
            passwordHash: out byte[] passwordHash,
            passwordSalt: out byte[] passwordSalt
        );
        User adminUser =
            new()
            {
                Id = 1,
                FirstName = "AdminFL",
                LastName = "AdminLN",
                Email = "admin@admin.com",
                Status = true,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
        
        HashingHelper.CreatePasswordHash(
            password: "sellerpassw",
            passwordHash: out byte[] sellerPasswordHash,
            passwordSalt: out byte[] sellerPasswordSalt
        );
        User sellerUser =
            new()
            {
                Id = 2,
                FirstName = "SellerFL",
                LastName = "SellerLN",
                Email = "seller@seller.com",
                Status = true,
                PasswordHash = sellerPasswordHash,
                PasswordSalt = sellerPasswordSalt
            };
    

        HashingHelper.CreatePasswordHash(
            password: "customerpassw",
            passwordHash: out byte[] customerPasswordHash,
            passwordSalt: out byte[] customerPasswordSalt
        );
        User customerUser =
            new()
            {
                Id = 3,
                FirstName = "CustomerFL",
                LastName = "CustomerLN",
                Email = "customer@customer.com",
                Status = true,
                PasswordHash = customerPasswordHash,
                PasswordSalt = customerPasswordSalt
            };

        List<User> users = new() { adminUser, sellerUser, customerUser };

        return users.ToArray();
    }
}
