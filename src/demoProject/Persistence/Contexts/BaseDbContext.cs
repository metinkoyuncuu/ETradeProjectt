using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Domain.Entities;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Bill> Bills { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Cashback> Cashbacks { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerAddress> CustomerAddresses { get; set; }
    public DbSet<CustomerCart> CustomerCarts { get; set; }
    public DbSet<CustomerCompare> CustomerCompares { get; set; }
    public DbSet<CustomerCoupon> CustomerCoupons { get; set; }
    public DbSet<CustomerCreditCard> CustomerCreditCards { get; set; }
    public DbSet<CustomerOrder> CustomerOrders { get; set; }
    public DbSet<CustomerWish> CustomerWishes { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Faq> Faqs { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductColor> ProductColors { get; set; }
    public DbSet<ProductFeature> ProductFeatures { get; set; }
    public DbSet<ProductFeatureTable> ProductFeatureTables { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<ProductQuestion> ProductQuestions { get; set; }
    public DbSet<ProductReview> ProductReviews { get; set; }
    public DbSet<ProductSize> ProductSizes { get; set; }
    public DbSet<ProductTag> ProductTags { get; set; }
    public DbSet<ProductVariant> ProductVariants { get; set; }
    public DbSet<ReviewFeedback> ReviewFeedbacks { get; set; }
    public DbSet<ReviewImage> ReviewImages { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Shipping> Shippings { get; set; }
    public DbSet<Shop> Shops { get; set; }
    public DbSet<ShopCoupon> ShopCoupons { get; set; }
    public DbSet<ShopImage> ShopImages { get; set; }
    public DbSet<ShopProduct> ShopProducts { get; set; }
    public DbSet<ShopSeller> ShopSellers { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TermCondition> TermConditions { get; set; }
    public DbSet<Log> Logs { get; set; }
    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {
        Configuration = configuration;
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
