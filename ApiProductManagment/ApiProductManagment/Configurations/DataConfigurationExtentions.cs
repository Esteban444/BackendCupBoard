using Microsoft.EntityFrameworkCore;
using ProductManagment.Infrastructure.Data;


namespace ApiProductManagment.Configurations
{
    public static class DataConfigurationExtentions
    {
        public static IServiceCollection DatabaseConfiguration(this IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION");
            services.AddDbContext<CupBoardContext>(x => x.UseSqlServer(connectionString!));
            return services;
        }
    }
}
