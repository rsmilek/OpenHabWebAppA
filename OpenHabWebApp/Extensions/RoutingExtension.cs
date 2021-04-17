using Microsoft.AspNetCore.Builder;

namespace OpenHabWebApp.Extensions
{
    public static class RoutingExtension
    {
        public static void ConfigureRouting(this IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
