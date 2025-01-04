using Microsoft.Extensions.DependencyInjection;
using UI.Views;

namespace UI
{
    internal class Navigator
    {
        private readonly IServiceProvider serviceProvider;

        public Navigator(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void ChangeView<TView>()
            where TView : IView
        {
            var type = typeof(TView);

            var view = (IView)serviceProvider.GetRequiredService(type);

            view.Display();
        }
    }
}
