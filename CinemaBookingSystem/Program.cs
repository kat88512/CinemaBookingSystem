using Microsoft.Extensions.DependencyInjection;
using UI;
using UI.Extensions;

var services = new ServiceCollection();

services.RegisterRepositories();
services.RegisterServices();

services.RegisterViews();

services.AddSingleton<IServiceProvider>(sp => sp);
services.AddSingleton<Navigator>();

services.AddSingleton<CinemaBookingSystem>();

var serviceProvider = services.BuildServiceProvider();

var app = serviceProvider.GetService<CinemaBookingSystem>();

app.Run();
