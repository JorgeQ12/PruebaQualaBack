using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PruebaBackQuala.Application.Interfaces;
using PruebaBackQuala.Application.Services;
using PruebaBackQuala.Domain;
using PruebaBackQuala.Interfaces;

namespace PruebaBackQuala
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PruebaBackQuala", Version = "v1" });
            });

            services.AddDbContext<DbContextQuala>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("QualaConnection")));

            services.AddCors(options => options.AddPolicy("AllowWebApp",
                            builder => builder.AllowAnyOrigin()
                                                .AllowAnyHeader()
                                                .AllowAnyMethod()));
            services.AddControllers(mvcOpts =>
            {
            });
            services.AddScoped<IQualaService, QualaService>();
            services.AddScoped<IQualaDomain, QualaDomain>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PruebaBackQuala v1"));
            }
            app.UseCors("AllowWebApp");

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
