using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderAccessors.Accessors.Implementations;
using OrderAccessors.Accessors.Interfaces;
using OrderAccessors.Contexts;
using OrderCore.MappingProfiles;
using OrderManagers.Implementations;
using OrderManagers.Interfaces;

namespace OrderAPI
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
            services.AddControllers();
            services.AddDbContext<OrderDbContext>(options =>
            {
                options
                    .UseNpgsql(Configuration.GetConnectionString("OrderDatabase"))
                    .UseSnakeCaseNamingConvention();
            });
            
            services.AddAutoMapper(typeof(OrderProfile).Assembly);
            services.AddScoped<IOrderDataAccessor, OrderDataAccessor>();
            services.AddScoped<IOrderManager, OrderManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
