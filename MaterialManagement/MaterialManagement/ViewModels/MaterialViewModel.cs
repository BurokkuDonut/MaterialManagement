using Caliburn.Micro;

namespace MaterialManagement.ViewModels
{
    public class MaterialViewModel : Screen
    {
        private readonly ShellViewModel _shellViewModel;

        public MaterialViewModel(ShellViewModel shellViewModel)
        {
            _shellViewModel = shellViewModel;
        }

        public void NavigateToEinkaufslisteView()
        {
            _shellViewModel.NavigateToShoppinglistView(this);
        }
    }
}