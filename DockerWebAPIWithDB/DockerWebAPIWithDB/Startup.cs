using DockerWebAPIWithDB.BusinessLogic.Interface;
using DockerWebAPIWithDB.BusinessLogic.Service;
using DockerWebAPIWithDB.Models;
using DockerWebAPIWithDB.Repositories.Interface;
using DockerWebAPIWithDB.Repositories.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.IO;
using System;

namespace DockerWebApp
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; private set; }

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IUserBL, UserBL>();
            services.AddTransient<IUserRepository, UserRepository>();
            //services.AddSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo
            //    {
            //        Title = "Docker Sample DB Service API",
            //        Version = "V1",
            //        Description = "Sample service for Learner",
            //    });
            //});
            services.AddDbContext<DBContext>(option =>
            option.UseSqlServer(Configuration.GetConnectionString("connectionString")));
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();
            app.UseCors();
            app.UseSwagger();
            app.UseSwaggerUI(options => { 
                options.SwaggerEndpoint("swagger/v1/swagger.json", "Docker Sample API Services");
                options.DocumentTitle = "Test API";
                options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                options.RoutePrefix = string.Empty;
            });

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
