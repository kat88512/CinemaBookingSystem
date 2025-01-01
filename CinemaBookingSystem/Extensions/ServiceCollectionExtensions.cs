using DataAccess.Repositories.CinemaRepositories;
using DataAccess.Repositories.MovieRepositories;
using DataAccess.Repositories.OrderRepositories;
using DataAccess.Repositories.ScreeningRepositories;
using Microsoft.Extensions.DependencyInjection;
using Services.Services;
using UI.Views;

namespace UI.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static ServiceCollection RegisterRepositories(this ServiceCollection services)
        {
            services.AddSingleton<ICinemaRepository, CinemaInMemoryRepository>();
            services.AddSingleton<ICinemaRoomRepository, CinemaRoomInMemoryRepository>();

            services.AddSingleton<IMovieRepository, MovieInMemoryRepository>();

            services.AddSingleton<IOrderRepository, OrderInMemoryRepository>();

            services.AddSingleton<IScreeningRepository, ScreeningInMemoryRepository>();
            services.AddSingleton<IScreeningSeatRepository, ScreeningSeatInMemoryRepository>();

            return services;
        }

        public static ServiceCollection RegisterServices(this ServiceCollection services)
        {
            services.AddScoped<CinemaService>();
            services.AddScoped<OrderService>();

            services.AddScoped<ScreeningService>();
            services.AddScoped<ScreeningSeatService>();

            return services;
        }

        public static ServiceCollection RegisterViews(this ServiceCollection services)
        {
            services.AddTransient<ScreeningsView>();
            services.AddTransient<SeatPlanView>();
            services.AddTransient<SummaryView>();

            return services;
        }
    }
}
