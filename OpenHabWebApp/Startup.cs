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
using OpenHabWebApp.Extensions;
using System;
using System.Linq;

namespace OpenHabWebAppA
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataService(Configuration);
            services.AddControllersWithViews();
            services.AddSpaService();
            services.AddCorsService();
            services.AddSwaggerGen(); // Register the Swagger generator, defining 1 or more Swagger documents
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext dataContext)
        {
            app.ConfigureExceptionPage(env);
            app.UseCors(CorsExtension.MyAllowSpecificOrigins);
            app.UseHttpsRedirection();
            app.ConfigureStaticFiles(env);
            app.ConfigureSwagger();
            app.ConfigureRouting();
            app.ConfigureSpa(env);


            dataContext.Database.EnsureDeleted();
            dataContext.Database.EnsureCreated();
            dataContext.Esp32camImages.Add(new Esp32camImage() { CreatedAt = new DateTime(2020, 11, 8, 11, 40, 0), Name = "Pokus 1" });
            dataContext.Esp32camImages.Add(new Esp32camImage() { CreatedAt = new DateTime(2020, 11, 8, 11, 50, 0), Name = "Pokus 2" });
            dataContext.SaveChanges();

            var imgs = dataContext.Esp32camImages.ToList();
        }
    }
}
