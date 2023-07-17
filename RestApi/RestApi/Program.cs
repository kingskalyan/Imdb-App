using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;



namespace RestApi
{
    public class RestApi
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder().Build().Run();
        }
        public static IHostBuilder CreateWebHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
