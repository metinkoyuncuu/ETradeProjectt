using Application.Services.AuthenticatorService;
using Application.Services.AuthService;
using Application.Services.UsersService;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Core.Application.Pipelines.Validation;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.CrossCuttingConcerns.Logging.Serilog.Logger;
using Core.ElasticSearch;
using Core.Mailing;
using Core.Mailing.MailKitImplementations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Services.Bills;
using Application.Services.Brands;
using Application.Services.Carts;
using Application.Services.Cashbacks;
using Application.Services.Categories;
using Application.Services.Cities;
using Application.Services.Colors;
using Application.Services.Coupons;
using Application.Services.Customers;
using Application.Services.CustomerAddresses;
using Application.Services.CustomerCarts;
using Application.Services.CustomerCompares;
using Application.Services.CustomerCoupons;
using Application.Services.CustomerCreditCards;
using Application.Services.CustomerOrders;
using Application.Services.CustomerWishes;
using Application.Services.Districts;
using Application.Services.Faqs;
using Application.Services.Genders;
using Application.Services.Images;
using Application.Services.Orders;
using Application.Services.OrderProducts;
using Application.Services.Products;
using Application.Services.ProductCategories;
using Application.Services.ProductColors;
using Application.Services.ProductFeatures;
using Application.Services.ProductFeatureTables;
using Application.Services.ProductImages;
using Application.Services.ProductQuestions;
using Application.Services.ProductReviews;
using Application.Services.ProductSizes;
using Application.Services.ProductTags;
using Application.Services.ProductVariants;
using Application.Services.ReviewFeedbacks;
using Application.Services.ReviewImages;
using Application.Services.Sellers;
using Application.Services.Shippings;
using Application.Services.Shops;
using Application.Services.ShopCoupons;
using Application.Services.ShopImages;
using Application.Services.ShopProducts;
using Application.Services.ShopSellers;
using Application.Services.Sizes;
using Application.Services.SubCategories;
using Application.Services.Tags;
using Application.Services.TermConditions;
using Application.Services.ContextOperations;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddSingleton<IMailService, MailKitMailService>();
        services.AddSingleton<LoggerServiceBase, FileLogger>();
        services.AddSingleton<IElasticSearch, ElasticSearchManager>();
        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IAuthenticatorService, AuthenticatorManager>();
        services.AddScoped<IUserService, UserManager>();

        services.AddScoped<IContextOperationsService, ContextOperationsManager>();

        services.AddScoped<IBillsService, BillsManager>();
        services.AddScoped<IBrandsService, BrandsManager>();
        services.AddScoped<ICartsService, CartsManager>();
        services.AddScoped<ICartsService, CartsManager>();
        services.AddScoped<ICashbacksService, CashbacksManager>();
        services.AddScoped<ICategoriesService, CategoriesManager>();
        services.AddScoped<ICitiesService, CitiesManager>();
        services.AddScoped<IColorsService, ColorsManager>();
        services.AddScoped<ICouponsService, CouponsManager>();
        services.AddScoped<ICustomersService, CustomersManager>();
        services.AddScoped<ICustomerAddressesService, CustomerAddressesManager>();
        services.AddScoped<ICustomerCartsService, CustomerCartsManager>();
        services.AddScoped<ICustomerComparesService, CustomerComparesManager>();
        services.AddScoped<ICustomerCouponsService, CustomerCouponsManager>();
        services.AddScoped<ICustomerCreditCardsService, CustomerCreditCardsManager>();
        services.AddScoped<ICustomerOrdersService, CustomerOrdersManager>();
        services.AddScoped<ICustomerWishesService, CustomerWishesManager>();
        services.AddScoped<IDistrictsService, DistrictsManager>();
        services.AddScoped<IFaqsService, FaqsManager>();
        services.AddScoped<IGendersService, GendersManager>();
        services.AddScoped<IImagesService, ImagesManager>();
        services.AddScoped<IOrdersService, OrdersManager>();
        services.AddScoped<IOrderProductsService, OrderProductsManager>();
        services.AddScoped<IProductsService, ProductsManager>();
        services.AddScoped<IProductsService, ProductsManager>();
        services.AddScoped<IProductCategoriesService, ProductCategoriesManager>();
        services.AddScoped<IProductColorsService, ProductColorsManager>();
        services.AddScoped<IProductFeaturesService, ProductFeaturesManager>();
        services.AddScoped<IProductFeatureTablesService, ProductFeatureTablesManager>();
        services.AddScoped<IProductImagesService, ProductImagesManager>();
        services.AddScoped<IProductQuestionsService, ProductQuestionsManager>();
        services.AddScoped<IProductReviewsService, ProductReviewsManager>();
        services.AddScoped<IProductSizesService, ProductSizesManager>();
        services.AddScoped<IProductTagsService, ProductTagsManager>();
        services.AddScoped<IProductVariantsService, ProductVariantsManager>();
        services.AddScoped<IReviewFeedbacksService, ReviewFeedbacksManager>();
        services.AddScoped<IReviewImagesService, ReviewImagesManager>();
        services.AddScoped<ISellersService, SellersManager>();
        services.AddScoped<IShippingsService, ShippingsManager>();
        services.AddScoped<IShopsService, ShopsManager>();
        services.AddScoped<IShopCouponsService, ShopCouponsManager>();
        services.AddScoped<IShopImagesService, ShopImagesManager>();
        services.AddScoped<IShopProductsService, ShopProductsManager>();
        services.AddScoped<IShopSellersService, ShopSellersManager>();
        services.AddScoped<ISizesService, SizesManager>();
        services.AddScoped<ISubCategoriesService, SubCategoriesManager>();
        services.AddScoped<ITagsService, TagsManager>();
        services.AddScoped<ITermConditionsService, TermConditionsManager>();
        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (Type? item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}
