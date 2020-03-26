using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using supermarket.API.Services;
using supermarket.API.Domain.Services;
using supermarket.API.Domain.Repositories;
using supermarket.API.Persistence.Repositories;
using supermarket.API.Persistence.Contexts;
using supermarket.API.Domain.Models;

namespace supermarket.API
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
            services.AddMvc();
            services.AddControllers();

            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("supermarket-in-memory"));
            services.AddScoped<IListRepository<Category>, CategoryRepository>();
            services.AddScoped<IListService<Category>, CategoryService>();
            services.AddScoped<IListRepository<Product>, ProductRepository>();
            services.AddScoped<IListService<Product>, ProductService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
