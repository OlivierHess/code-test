using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CodeTest.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(opts =>
            {
                opts.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
                opts.SuppressAsyncSuffixInActionNames = true;
            });

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
