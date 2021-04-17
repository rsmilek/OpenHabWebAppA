using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenHabWebApp.Data;
using OpenHabWebApp.Domain;
using System;
using System.Linq;

namespace OpenHabWebAppA
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var databaseSection = Configuration.GetSection(DataConfiguration.Section);
            services.Configure<DataConfiguration>(databaseSection);
            services.AddDbContext<DataContext>(optionsBuilder =>
                optionsBuilder.UseSqlite(databaseSection.Get<DataConfiguration>().ConnectionString));

            services.AddControllersWithViews();
            
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            
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

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext dataContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

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

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    // Launch Angular development web server every application start - consumes additional time :-(
                    //// spa.UseAngularCliServer(npmScript: "start");

                    // Uses proxy to development web server - faster :-(
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });



            dataContext.Database.EnsureDeleted();
            dataContext.Database.EnsureCreated();
            dataContext.Esp32camImages.Add(new Esp32camImage() { CreatedAt = new DateTime(2020, 11, 8, 11, 40, 0), Name = "Pokus 1" });
            dataContext.Esp32camImages.Add(new Esp32camImage() { CreatedAt = new DateTime(2020, 11, 8, 11, 50, 0), Name = "Pokus 2" });
            dataContext.SaveChanges();

            var imgs = dataContext.Esp32camImages.ToList();
        }
    }
}
