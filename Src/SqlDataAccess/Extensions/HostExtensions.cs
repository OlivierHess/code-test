using CodeTest.SqlDataAccess.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace CodeTest.SqlDataAccess.Extensions
{
    public static class HostExtensions
    {
        public static IHost CreateDbIfNotExists(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<CodeTestContext>();
                CodeTestContextInitialiser.Initialise(context);
            }
            catch (Exception exception)
            {
                var logger = services.GetRequiredService<ILogger<CodeTestContext>>();
                logger.LogError(exception, "An error occurred creating the DB.");
            }

            return host;
        }
    }
}