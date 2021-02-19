using CodeTest.Domain.Areas.Products.Commands;
using CodeTest.SqlDataAccess.Data;
using CodeTest.SqlDataAccess.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CodeTest.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(opts =>
            {
                opts.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
                opts.SuppressAsyncSuffixInActionNames = true;
            });

            services.AddDbContext<CodeTestContext>(options
                => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddRepositories();

            services.AddMediatR(typeof(Startup), typeof(CreateProductCommand));

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(opts => opts.SwaggerEndpoint(
                "/swagger/v1/swagger.json",
                "Code Test API"));

            app.UseHttpsRedirection().UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
