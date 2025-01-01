using Microsoft.Extensions.DependencyInjection;
using Services.Seeders;
using UI;
using UI.DataContext;
using UI.Extensions;

var services = new ServiceCollection();

services.RegisterRepositories();
services.RegisterServices();

services.AddScoped<SessionContext>();

services.RegisterViews();

services.AddSingleton<IServiceProvider>(sp => sp);
services.AddSingleton<Navigator>();

services.AddScoped<MainSeeder>();
services.AddSingleton<CinemaBookingSystem>();

var serviceProvider = services.BuildServiceProvider();

var app = serviceProvider.GetService<CinemaBookingSystem>();

app.Run();
