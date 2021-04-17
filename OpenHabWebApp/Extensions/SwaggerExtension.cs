using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenHabWebApp.Extensions
{
    public static class SwaggerExtension
    {
        public static void ConfigureSwagger(this IApplicationBuilder app) 
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api/swagger/{documentname}/swagger.json";
            });
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "My Cool API V1");
                c.RoutePrefix = "api/swagger";
            });
        }
    }
}
