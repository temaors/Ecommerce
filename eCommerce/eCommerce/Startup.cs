using eCommerce.Database.DbEntities;
using eCommerce.Database.Repositories;
using Microsoft.OpenApi.Models;

namespace eCommerce
{
    public static class Startup
    {
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.ConfigureSwagger();
            //builder.ConfigureRepositories();
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

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUI();
        }

        private static void ConfigureRepositories(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(typeof(IRepository<User>), typeof(Repository<User>));
        }
    }
}