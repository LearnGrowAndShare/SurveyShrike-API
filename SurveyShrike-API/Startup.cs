using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SurveyShrike_API.Application.Infrastructure;
using SurveyShrike_API.Application.Infrastructure.Automapper;
using SurveyShrike_API.Application.Interfaces;
using SurveyShrike_API.Application.Surveys.Queries.GetSurveyDetails;
using SurveyShrike_API.Persistence;

using System;
using System.Reflection;

namespace SurveyShrike_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            IWebHostEnvironment env = serviceProvider.GetService<IWebHostEnvironment>();
            services.AddControllers();
            services.AddAuthorization();
        
            services.AddAuthentication("Bearer")
              .AddJwtBearer("Bearer", options =>
              {
                  options.Authority = Configuration["Authority"] ?? "http://localhost:5000";
                  options.RequireHttpsMetadata = false;
                  options.Audience = "api";
              });

            services.AddCors(setup =>
            {
                setup.AddDefaultPolicy(policy =>
                {
                    policy
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(type => type.ToString());
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IApplicationDBContext, ApplicationDBContext>();

            // Add MediatR
            services.AddMediatR(typeof(GetSurveyDetailQueryHandler).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            
            // Add AutoMapper
            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });

            // Add DbContext using SQL Server Provider
            services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlite(GetConnectionString(env.IsDevelopment())).UseLazyLoadingProxies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity server");

            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private string GetConnectionString(bool isDevelopment)
        {
            IConfigurationRoot configuration = null;
            if (isDevelopment)
            {
                configuration = new ConfigurationBuilder()
                           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                           .AddJsonFile("appsettings.json")
                           .AddJsonFile("appsettings.development.json", true)
                           .Build();

                return configuration.GetConnectionString("Database");
            }
            else
            {

                configuration = new ConfigurationBuilder()
                           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                           .AddJsonFile("appsettings.json")
                           .Build();
                return configuration.GetConnectionString("Database");
            }


        }
    }
}
