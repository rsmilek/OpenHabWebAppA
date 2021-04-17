using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace OpenHabWebApp.Extensions
{
    public static class StaticFilesExtension
    {
        public static void ConfigureStaticFiles(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }
        }
    }
}
