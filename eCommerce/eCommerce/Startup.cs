using eCommerce.Database.DbEntities;
using eCommerce.Database.Repositories;
using eCommerce.Database.UnitOfWork;
using eCommerce.MappingProfiles;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.OpenApi.Models;

namespace eCommerce
{
    public static class Startup
    {
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.ConfigureSwagger();
            builder.ConfigureRepositories();
            builder.ConfigureMappers();
            builder.Services.AddHttpLogging(opts =>
            {
                opts.LoggingFields = HttpLoggingFields.All;
            });
        }

        private static void ConfigureMappers(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(UserMappingProfile));
            builder.Services.AddAutoMapper(typeof(ProductMappingProfile));
        }

        private static void ConfigureSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "eCommerce API",
                    Description = "Intelligence Marketplace",
                });
            });
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMvcWithDefaultRoute();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpLogging();
        }

        private static void ConfigureRepositories(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<IRepository<User>, UserRepository>();
            builder.Services.AddTransient<IRepository<Product>, ProductRepository>();
            builder.Services.AddTransient<IRepository<Category>, CategoryRepository>();
            builder.Services.AddTransient<IRepository<SubCategory>, SubcategoryRepository>();
            builder.Services.AddTransient<IRepository<FeedBack>, FeedBackRepository>();
            builder.Services.AddTransient<IRepository<Sale>, SaleRepository>();
            builder.Services.AddTransient<IRepository<Seller>, SellerRepository>();
            builder.Services.AddTransient<IRepository<Cart>, CartRepository>();
            builder.Services.AddTransient<IRepository<CartElement>, CartElementRepository>();
            builder.Services.AddTransient<IRepository<UsersFavourites>, UserFavouritesRepository>();
            builder.Services.AddTransient<IRepository<UsersAddresses>, UsersAddressesRepository>();
        }
    }
}