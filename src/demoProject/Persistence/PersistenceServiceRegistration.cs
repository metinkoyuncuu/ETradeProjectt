using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<BaseDbContext>(
        //                options => options
        //                .UseSqlServer(configuration
        //                .GetConnectionString
        //                ("ETradeConnectionString")
        //            ));
        services.AddDbContext<BaseDbContext>(options => options.UseInMemoryDatabase("nArchitecture"));
        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

        services.AddScoped<IBillRepository, BillRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<ICashbackRepository, CashbackRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<IColorRepository, ColorRepository>();
        services.AddScoped<ICouponRepository, CouponRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ICustomerAddressRepository, CustomerAddressRepository>();
        services.AddScoped<ICustomerCartRepository, CustomerCartRepository>();
        services.AddScoped<ICustomerCompareRepository, CustomerCompareRepository>();
        services.AddScoped<ICustomerCouponRepository, CustomerCouponRepository>();
        services.AddScoped<ICustomerCreditCardRepository, CustomerCreditCardRepository>();
        services.AddScoped<ICustomerOrderRepository, CustomerOrderRepository>();
        services.AddScoped<ICustomerWishRepository, CustomerWishRepository>();
        services.AddScoped<IDistrictRepository, DistrictRepository>();
        services.AddScoped<IFaqRepository, FaqRepository>();
        services.AddScoped<IGenderRepository, GenderRepository>();
        services.AddScoped<IImageRepository, ImageRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderProductRepository, OrderProductRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
        services.AddScoped<IProductColorRepository, ProductColorRepository>();
        services.AddScoped<IProductFeatureRepository, ProductFeatureRepository>();
        services.AddScoped<IProductFeatureTableRepository, ProductFeatureTableRepository>();
        services.AddScoped<IProductImageRepository, ProductImageRepository>();
        services.AddScoped<IProductQuestionRepository, ProductQuestionRepository>();
        services.AddScoped<IProductReviewRepository, ProductReviewRepository>();
        services.AddScoped<IProductSizeRepository, ProductSizeRepository>();
        services.AddScoped<IProductTagRepository, ProductTagRepository>();
        services.AddScoped<IProductVariantRepository, ProductVariantRepository>();
        services.AddScoped<IReviewFeedbackRepository, ReviewFeedbackRepository>();
        services.AddScoped<IReviewImageRepository, ReviewImageRepository>();
        services.AddScoped<ISellerRepository, SellerRepository>();
        services.AddScoped<IShippingRepository, ShippingRepository>();
        services.AddScoped<IShopRepository, ShopRepository>();
        services.AddScoped<IShopCouponRepository, ShopCouponRepository>();
        services.AddScoped<IShopImageRepository, ShopImageRepository>();
        services.AddScoped<IShopProductRepository, ShopProductRepository>();
        services.AddScoped<IShopSellerRepository, ShopSellerRepository>();
        services.AddScoped<ISizeRepository, SizeRepository>();
        services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<ITermConditionRepository, TermConditionRepository>();
        return services;
    }
}
