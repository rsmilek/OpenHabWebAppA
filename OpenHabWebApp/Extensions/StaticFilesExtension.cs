using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
