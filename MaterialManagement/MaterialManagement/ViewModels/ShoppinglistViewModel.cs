using Caliburn.Micro;

namespace MaterialManagement.ViewModels
{
    public class ShoppinglistViewModel : Screen
    {
        private readonly EventAggregator _eventAggregator;

        public ShoppinglistViewModel(EventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public void NavigateToMaterialManagementView()
        {
            _eventAggregator.PublishOnCurrentThreadAsync(new NavigationEvent(typeof(MaterialViewModel)));
        }
    }
}