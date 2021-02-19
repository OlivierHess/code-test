using CodeTest.SqlDataAccess.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CodeTest.Api
{
    public class Program
    {
        public static void Main(string[] args)
            => CreateHostBuilder(args).Build().CreateDbIfNotExists().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder
                    => webBuilder.UseStartup<Startup>());
    }
}
