using Application.Features.OperationClaims.Constants;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasMany(oc => oc.UserOperationClaims);

        builder.HasData(getSeeds());
    }

    private HashSet<OperationClaim> getSeeds()
    {
        int id = 0;
        HashSet<OperationClaim> seeds =
            new()
            {
                new OperationClaim { Id = ++id, Name = GeneralOperationClaims.Admin },
                new OperationClaim { Id = ++id,Name= GeneralOperationClaims.Seller },
                new OperationClaim{Id=++id,Name=GeneralOperationClaims.Customer }
            };

        //seeds.Add(new() { Id=++id,Name=GeneralOperationClaims.Seller);
        //seeds.Add(new() { Id=++id,Name=GeneralOperationClaims.Customer});
        #region Brands
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Brands.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Brands.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Brands.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Brands.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Brands.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Brands.Delete" });
        
        #endregion
        
        
        #region Bills
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Bills.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Bills.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Bills.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Bills.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Bills.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Bills.Delete" });
        
        #endregion
        
        
        #region Brands
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Brands.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Brands.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Brands.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Brands.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Brands.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Brands.Delete" });
        
        #endregion
        
        
        #region Carts
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Carts.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Carts.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Carts.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Carts.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Carts.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Carts.Delete" });
        
        #endregion
        
        
        #region Carts
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Carts.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Carts.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Carts.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Carts.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Carts.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Carts.Delete" });
        
        #endregion
        
        
        #region Cashbacks
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cashbacks.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cashbacks.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cashbacks.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cashbacks.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cashbacks.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cashbacks.Delete" });
        
        #endregion
        
        
        #region Categories
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Delete" });
        
        #endregion
        
        
        #region Cities
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Delete" });
        
        #endregion
        
        
        #region Colors
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Colors.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Colors.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Colors.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Colors.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Colors.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Colors.Delete" });
        
        #endregion
        
        
        #region Coupons
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Coupons.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Coupons.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Coupons.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Coupons.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Coupons.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Coupons.Delete" });
        
        #endregion
        
        
        #region Customers
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Delete" });
        
        #endregion
        
        
        #region CustomerAddresses
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerAddresses.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerAddresses.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerAddresses.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerAddresses.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerAddresses.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerAddresses.Delete" });
        
        #endregion
        
        
        #region CustomerCarts
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCarts.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCarts.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCarts.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCarts.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCarts.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCarts.Delete" });
        
        #endregion
        
        
        #region CustomerCompares
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCompares.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCompares.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCompares.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCompares.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCompares.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCompares.Delete" });
        
        #endregion
        
        
        #region CustomerCoupons
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCoupons.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCoupons.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCoupons.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCoupons.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCoupons.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCoupons.Delete" });
        
        #endregion
        
        
        #region CustomerCreditCards
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCreditCards.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCreditCards.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCreditCards.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCreditCards.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCreditCards.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCreditCards.Delete" });
        
        #endregion
        
        
        #region CustomerOrders
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerOrders.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerOrders.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerOrders.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerOrders.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerOrders.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerOrders.Delete" });
        
        #endregion
        
        
        #region CustomerWishes
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerWishes.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerWishes.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerWishes.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerWishes.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerWishes.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerWishes.Delete" });
        
        #endregion
        
        
        #region Districts
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Delete" });
        
        #endregion
        
        
        #region Faqs
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Faqs.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Faqs.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Faqs.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Faqs.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Faqs.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Faqs.Delete" });
        
        #endregion
        
        
        #region Genders
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Genders.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Genders.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Genders.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Genders.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Genders.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Genders.Delete" });
        
        #endregion
        
        
        #region Images
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Images.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Images.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Images.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Images.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Images.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Images.Delete" });
        
        #endregion
        
        
        #region Orders
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Orders.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Orders.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Orders.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Orders.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Orders.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Orders.Delete" });
        
        #endregion
        
        
        #region OrderProducts
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "OrderProducts.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "OrderProducts.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "OrderProducts.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "OrderProducts.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "OrderProducts.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "OrderProducts.Delete" });
        
        #endregion
        
        
        #region Products
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Products.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Products.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Products.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Products.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Products.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Products.Delete" });
        
        #endregion
        
        
        #region Products
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Products.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Products.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Products.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Products.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Products.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Products.Delete" });
        
        #endregion
        
        
        #region ProductCategories
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductCategories.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductCategories.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductCategories.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductCategories.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductCategories.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductCategories.Delete" });
        
        #endregion
        
        
        #region ProductColors
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductColors.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductColors.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductColors.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductColors.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductColors.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductColors.Delete" });
        
        #endregion
        
        
        #region ProductFeatures
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductFeatures.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductFeatures.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductFeatures.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductFeatures.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductFeatures.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductFeatures.Delete" });
        
        #endregion
        
        
        #region ProductFeatureTables
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductFeatureTables.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductFeatureTables.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductFeatureTables.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductFeatureTables.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductFeatureTables.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductFeatureTables.Delete" });
        
        #endregion
        
        
        #region ProductImages
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductImages.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductImages.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductImages.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductImages.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductImages.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductImages.Delete" });
        
        #endregion
        
        
        #region ProductQuestions
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductQuestions.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductQuestions.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductQuestions.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductQuestions.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductQuestions.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductQuestions.Delete" });
        
        #endregion
        
        
        #region ProductReviews
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductReviews.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductReviews.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductReviews.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductReviews.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductReviews.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductReviews.Delete" });
        
        #endregion
        
        
        #region ProductSizes
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductSizes.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductSizes.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductSizes.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductSizes.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductSizes.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductSizes.Delete" });
        
        #endregion
        
        
        #region ProductTags
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductTags.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductTags.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductTags.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductTags.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductTags.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductTags.Delete" });
        
        #endregion
        
        
        #region ProductVariants
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductVariants.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductVariants.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductVariants.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductVariants.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductVariants.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProductVariants.Delete" });
        
        #endregion
        
        
        #region ReviewFeedbacks
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ReviewFeedbacks.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ReviewFeedbacks.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ReviewFeedbacks.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ReviewFeedbacks.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ReviewFeedbacks.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ReviewFeedbacks.Delete" });
        
        #endregion
        
        
        #region ReviewImages
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ReviewImages.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ReviewImages.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ReviewImages.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ReviewImages.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ReviewImages.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ReviewImages.Delete" });
        
        #endregion
        
        
        #region Sellers
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sellers.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sellers.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sellers.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sellers.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sellers.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sellers.Delete" });
        
        #endregion
        
        
        #region Shippings
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Shippings.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Shippings.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Shippings.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Shippings.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Shippings.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Shippings.Delete" });
        
        #endregion
        
        
        #region Shops
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Shops.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Shops.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Shops.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Shops.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Shops.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Shops.Delete" });
        
        #endregion
        
        
        #region ShopCoupons
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ShopCoupons.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ShopCoupons.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ShopCoupons.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ShopCoupons.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ShopCoupons.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ShopCoupons.Delete" });
        
        #endregion
        
        
        #region ShopImages
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ShopImages.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ShopImages.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ShopImages.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ShopImages.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ShopImages.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ShopImages.Delete" });
        
        #endregion
        
        
        #region ShopProducts
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ShopProducts.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ShopProducts.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ShopProducts.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ShopProducts.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ShopProducts.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ShopProducts.Delete" });
        
        #endregion
        
        
        #region ShopSellers
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ShopSellers.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ShopSellers.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ShopSellers.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ShopSellers.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ShopSellers.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ShopSellers.Delete" });
        
        #endregion
        
        
        #region Sizes
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sizes.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sizes.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sizes.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sizes.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sizes.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sizes.Delete" });
        
        #endregion
        
        
        #region SubCategories
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "SubCategories.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "SubCategories.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SubCategories.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "SubCategories.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SubCategories.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SubCategories.Delete" });
        
        #endregion
        
        
        #region Tags
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Tags.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Tags.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Tags.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Tags.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Tags.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Tags.Delete" });
        
        #endregion
        
        
        #region TermConditions
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "TermConditions.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "TermConditions.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "TermConditions.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "TermConditions.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "TermConditions.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "TermConditions.Delete" });

        #endregion
        #region Logs

        seeds.Add(new OperationClaim { Id = ++id, Name = "Logs.Admin" });

        seeds.Add(new OperationClaim { Id = ++id, Name = "Logs.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Logs.Write" });

        seeds.Add(new OperationClaim { Id = ++id, Name = "Logs.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Logs.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Logs.Delete" });

        #endregion
        return seeds;
    }
    
   
    
   
 
   
}
