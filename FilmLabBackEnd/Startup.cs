using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmLabBackEnd.Data;
using FilmLabBackEnd.Helpers;
using FilmLabBackEnd.Options;
using FilmLabBackEnd.Data;
using FilmLabBackEnd.Helpers;
using FilmLabBackEnd.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace FilmLabBackEnd

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
            services.AddCors();
            services.AddDirectoryBrowser();

            
            services.AddMvc();
            
            services.AddControllers();
            
            
            services.AddScoped<DataRepository>(x =>
                new DataRepository(Configuration.GetConnectionString("DbConnection")));
            

            services.AddScoped<JwtService>();


            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

            app.UseStaticFiles();
            app.UseFileServer();

            app.UseRouting();

            app.UseCors(options=>options
                .WithOrigins(new []{"http://localhost:7050","http://localhost:5043"})
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
            );

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern:"{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}