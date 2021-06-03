using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Microsoft.OpenApi.Models;
using empresax.permiso.api.application.service;
using empresax.permiso.api.application.transform;
using empresax.permiso.api.application.validator;
using empresax.permiso.api.infraestructure.transform;
using empresax.permiso.api.infraestructure.transform.mapper;
using empresax.permiso.api.infraestructure.Controllers;
using empresax.permiso.api.domain.repository;
using empresax.permiso.api.infraestructure.repository;

namespace empresax.permiso.api
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
            services.AddScoped<IPermissionsController, PermissionsController>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IPermissionTransform, PermissionTransform>();
            services.AddScoped<IPermissionValidator, PermissionValidator>();

            services.AddScoped<IPermissionTypeController, PermissionTypeController>();
            services.AddScoped<IPermissionTypeService, PermissionTypeService>();
            services.AddScoped<IPermissionTypeRepository, PermissionTypeRepository>();
            services.AddScoped<IPermissionTypeTransform, PermissionTypeTransform>();
            services.AddScoped<IPermissionTypeValidator, PermissionTypeValidator>();
            
            services.AddAutoMapper(typeof(PermissionProfile));
            services.AddCors(options =>
            {
                options.AddPolicy("AllowFromAll",
                    builder => builder
                    .WithMethods("GET", "POST", "PUT", "DELETE")
                    .AllowAnyOrigin()
                    .AllowAnyHeader());
            }); ;

            AddSwagger(services);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowFromAll");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>{
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            // swagger end

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }



        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                        Title = $"Permisos {groupName}",
                        Version = groupName,
                        Description = "API",
                        Contact = new OpenApiContact
                        {
                            Name = "Ivan Calapuja",
                            Email = "icalapuja@gmail.com",
                            Url = new Uri("https://icalapuja.github.io/"),
                        }
                });
            });
        }

    }
}
