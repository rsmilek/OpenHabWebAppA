using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenHabWebApp.Extensions
{
    public static class CorsExtension
    {
        public const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public static void AddCorsService(this IServiceCollection services)
        {
            // Apply a CORS policy to all the app's endpoints with the specified origins
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins, builder =>
                {
                    builder.WithOrigins(
                        "http://localhost:5000", "https://localhost:5001",
                        "http://localhost:34160", "https://localhost:44350")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }
    }
}
