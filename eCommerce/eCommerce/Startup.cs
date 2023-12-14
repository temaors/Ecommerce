using eCommerce.Database.DbEntities;
using eCommerce.Database.Repositories;
using eCommerce.MappingProfiles;
using Microsoft.OpenApi.Models;

namespace eCommerce
{
    public static class Startup
    {
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.ConfigureSwagger();
            //builder.ConfigureRepositories();
            builder.ConfigureMappers();
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
        }

        private static void ConfigureRepositories(this WebApplicationBuilder builder)
        {
            //builder.Services.AddScoped(typeof(IRepository<User>), typeof(Repository<User>));
        }
    }
}