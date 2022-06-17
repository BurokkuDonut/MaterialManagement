using Caliburn.Micro;
using MaterialManagement.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MaterialManagement.ViewModels
{
    public class ShoppinglistViewModel : Screen
    {
        private readonly EventAggregator _eventAggregator;
        private readonly DataProvider dataProvider;

        public ShoppinglistViewModel(EventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            dataProvider = new DataProvider();
            Material= new ObservableCollection<Material>(dataProvider.GetMaterials().Where(x => x.MinimalCount > x.Count)
                .Select(x => new Material() {Name=x.Name, ToBeOrdered = x.MinimalCount-x.Count }));
        }

        public string ShoppingListTextBox { get; set; }
        public ObservableCollection<Material> Material { get; set; }

        public void NavigateToMaterialManagementView()
        {
            _eventAggregator.PublishOnCurrentThreadAsync(new NavigationEvent(typeof(MaterialViewModel)));
        }

        public void AddToShoppingList(ActionExecutionContext context)
        {
            if((context.EventArgs as KeyEventArgs).Key == Key.Enter)
            {
                Material.Add(new Material() { Name = ShoppingListTextBox });
            }
        }

        public void Add(Material material)
        {
            material.ToBeOrdered += 1;
            NotifyOfPropertyChange(null);
        }
        
        public void Remove(Material material)
        {
            material.ToBeOrdered -= 1;
            NotifyOfPropertyChange(null);
        }

        public void Delete(Material material)
        {
            Material.Remove(material);
            NotifyOfPropertyChange(null);
        }

    }
}