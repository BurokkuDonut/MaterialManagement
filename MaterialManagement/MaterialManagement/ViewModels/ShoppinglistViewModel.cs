using Caliburn.Micro;

namespace MaterialManagement.ViewModels
{
    public class ShoppinglistViewModel : Screen
    {
        private readonly ShellViewModel _shellViewModel;

        public ShoppinglistViewModel(ShellViewModel shellViewModel)
        {
            _shellViewModel = shellViewModel;
        }

        public void NavigateToMaterialManagementView()
        {
            _shellViewModel.LoadMaterialManagementView(this);
        }
    }
}