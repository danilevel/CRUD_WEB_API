using CRUD_WEB_API.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CRUD_WEB_API.Interfaces
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
            //services.AddIdentityCore<User>(
            //    opt =>
            //    {
            //        opt.Password.RequireDigit = true;
            //        opt.Password.RequiredLength = 10;
            //    })
            //    .AddDefaultTokenProviders()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}