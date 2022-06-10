using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace MaterialManagement.ViewModels
{
    public class ShellViewModel : Conductor<Screen>.Collection.OneActive, IHandle<NavigationEvent>
    {
        private readonly EventAggregator _eventAggregator;

        public ShellViewModel()
        {
            _eventAggregator = new EventAggregator();
            _eventAggregator.SubscribeOnPublishedThread(this);
            LoadDefault();
        }

        public void LoadDefault()
        {
            ActivateItemAsync(new MaterialViewModel(_eventAggregator));
        }

        public Task HandleAsync(NavigationEvent message, CancellationToken cancellationToken)
        {
            switch (message.NavigateTo)
            {
                case "MaterialViewModel":
                    ActivateItemAsync(new MaterialViewModel(_eventAggregator));
                    break;
                case "ShoppinglistViewModel":
                    ActivateItemAsync(new ShoppinglistViewModel(_eventAggregator));
                    break;
            }

            return Task.CompletedTask;
        }
    }
}