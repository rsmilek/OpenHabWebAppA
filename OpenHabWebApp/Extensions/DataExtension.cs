using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenHabWebApp.Data;

namespace OpenHabWebApp.Extensions
{
    public static class DataExtension
    {
        public static void AddDataService(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseSection = configuration.GetSection(DataConfiguration.Section);
            services.Configure<DataConfiguration>(databaseSection);
            services.AddDbContext<DataContext>(optionsBuilder =>
                optionsBuilder.UseSqlite(databaseSection.Get<DataConfiguration>().ConnectionString));
        }
    }
}
