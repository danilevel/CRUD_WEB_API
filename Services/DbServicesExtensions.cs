using Microsoft.EntityFrameworkCore;

namespace CRUD_WEB_API.Services
{
    public static class DbServicesExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

            return services;
        }
    }
}