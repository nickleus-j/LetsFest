using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LetsFest.Mysql
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMySqlDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<FestContext>(options =>
                options.UseMySQL(connectionString));
            return services;
        }
    }
}
