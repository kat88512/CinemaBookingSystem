using Microsoft.Extensions.DependencyInjection;
using UI.Views;

namespace UI
{
    internal class Navigator(IServiceProvider serviceProvider)
    {
        private readonly IServiceProvider serviceProvider = serviceProvider;

        public void ChangeView<TView>()
            where TView : IView
        {
            var type = typeof(TView);
            Console.WriteLine(type);
            var view = (IView)serviceProvider.GetRequiredService(type);

            view.Display();
        }
    }
}
