using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace MaterialManagement.ViewModels
{
    public class ShellViewModel : Conductor<Screen>.Collection.OneActive, IScreen
    {

        public ShellViewModel()
        {
            LoadDefault();
        }

        public void LoadDefault()
        {
            ActivateItemAsync(new MaterialViewModel(this));
            NotifyOfPropertyChange(null);
        }

        public void NavigateToShoppinglistView(MaterialViewModel materialViewModel)
        {
            DeactivateItemAsync(materialViewModel, true, CancellationToken.None);
            ActivateItemAsync(new ShoppinglistViewModel(this));
        }

        public void LoadMaterialManagementView(ShoppinglistViewModel shoppinglistViewModel)
        {
            DeactivateItemAsync(shoppinglistViewModel, true, CancellationToken.None);
            ActivateItemAsync(new MaterialViewModel(this));
        }
        
    }
}