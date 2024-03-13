using inventary.Data;
using Bussiness;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;

namespace inventary
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InventaryContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Sql") ?? throw new InvalidOperationException("Connection string 'PortalConsultasContext' not found."));
                options.EnableSensitiveDataLogging();
            });

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<WeatherForecastService>();
            services.AddScoped<B_Product>();
            services.AddScoped<B_Category>();
            services.AddScoped<B_Warehouse>();
            services.AddScoped<B_Storage>();
            services.AddScoped<IIntputOutput,B_InputOutput>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
