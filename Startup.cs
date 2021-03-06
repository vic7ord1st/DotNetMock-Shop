using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using mockshop.API.Services;
using mockshop.API.Domain.Services;
using mockshop.API.Domain.Repositories;
using mockshop.API.Persistence.Repositories;
using mockshop.API.Persistence.Contexts;
using mockshop.API.Domain.Models;
using mockshop.API.Resources;

namespace mockshop.API
{
    public class Startup
    {
        private ILogger<Startup> _logger;
        public IConfiguration Configuration { get; }
        public Startup(ILogger<Startup> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _logger.LogInformation("Configure service called");
            services.AddMvc();
            services.AddControllers();
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("mockshop-in-memory"));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(CategoryResource));
            services.AddAutoMapper(typeof(ProductResource));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            _logger.LogInformation("configure called");
            
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
