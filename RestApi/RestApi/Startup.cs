using Domain.Repository;
using Domain.Repository.Interfaces;
using Service;
using Service.Interfaces;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddScoped<IActorService, ActorService>();
        services.AddScoped<IProducerService, ProducerService>();
        services.AddScoped<IGenreService, GenreService>();
        services.AddScoped<IReviewService, ReviewService>();
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IActorRepository, ActorRepository>();
        services.AddScoped<IProducerRepository, ProducerRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddSingleton<IReviewRepository, ReviewRepository>();
        services.Configure<ConnectionStrings>(Configuration.GetSection(key: "ConnectionStrings"));

    }
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