using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RestaurantREST_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RestaurantREST_API
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
            services.AddControllers();
            services.AddDbContext<RestaurantLibrary.Entities.RestaurantContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DBContext"))
                
                );
            services.AddAutoMapper();
            services.AddScoped<IRestaurantInfoRepository, RestaurantInfoRepository>();

            services.AddSwaggerGen(c =>
            {
                //OpenApiInfo info = new OpenApiInfo();
                //info.Title = "RestaurantInfo API";
                //info.Version = "v1";

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RestaurantInfo API", Version = "v1" });
            }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c=>
                 {
                     c.SwaggerEndpoint("/swagger/v1/swagger.json","RestaurantInfo API");
                 }
                
                );


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
