// ReSharper disable All

using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Npgsql;


namespace Project1.Library;

    public static class DbContextTestHelper
    {
        private static readonly IHost _host;
        static DbContextTestHelper()
        {
            AutofacServiceProviderFactory provider = new AutofacServiceProviderFactory(configurationAction: builder =>
            {
                builder.RegisterType<CatalogService>().As<ICatalogService>().SingleInstance();
            });

            _host = Host.CreateDefaultBuilder()
                .UseServiceProviderFactory(provider)
                .ConfigureServices((context, services) =>
                {
                    services.AddPooledDbContextFactory<CatalogContext>(options =>
                        options.UseNpgsql("Host=localhost;Database=labs4;Username=postgres;Password=123"));
                })
                .Build();
        }

    public static int AddEntities()
    {
        using var scope = _host.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider.GetRequiredService<ICatalogService>();

        var director = new Director
        {
            FirstName = "Имя",
            LastName = "Фамилия",
        };

        var movie = new Movie
        {
            Title = "Название фильма",
            ReleaseYear = 2023,
            Director = director, 
        };

        return serviceProvider.AddMovie(movie); 
    }

    public static int UpdateEntities()
    {
        using var scope = _host.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider.GetRequiredService<ICatalogService>();

        var movieId = 3; 
        var updatedTitle = "Обновленное название фильма";

        return serviceProvider.UpdateMovie(movieId, updatedTitle); 
    }

    public static Movie ReadEntities()
    {
        using var scope = _host.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider.GetRequiredService<ICatalogService>();

        var movieId = 1; 

        return serviceProvider.ReadMovie(movieId); 
    }

    public static int RemoveEntities()
    {
        using var scope = _host.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider.GetRequiredService<ICatalogService>();

        var movieId = 3; 

        return serviceProvider.RemoveMovie(movieId);
    }
}