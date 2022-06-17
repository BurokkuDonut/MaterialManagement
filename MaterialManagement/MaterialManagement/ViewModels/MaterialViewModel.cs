using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using MaterialManagement.Models;

namespace MaterialManagement.ViewModels
{
    public class MaterialViewModel : Screen
    {
        private readonly IDataProvider _dataProvider;
        private readonly EventAggregator _eventAggregator;
        private string _amount;
        private ObservableCollection<Material> _materials;
        private string _minimalAmount;
        private string _name;
        private int _selectedMaterialIndex;

        public MaterialViewModel(EventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _dataProvider = new DataProvider();
            Materials = new ObservableCollection<Material>(_dataProvider.GetMaterials());
            Material.nextId = Materials.Count == 0 ? 0 : Materials.Select(x => x.Id).Max();
            SelectedMaterialIndex = -1;
        }

        public ObservableCollection<Material> Materials
        {
            get => _materials;
            set => _materials = value;
        }

        public int SelectedMaterialIndex
        {
            get => _selectedMaterialIndex;
            set
            {
                _selectedMaterialIndex = value;
                FillSettings(_selectedMaterialIndex);
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        public string Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                NotifyOfPropertyChange(() => Amount);
            }
        }

        public string MinimalAmount
        {
            get => _minimalAmount;
            set
            {
                _minimalAmount = value;
                NotifyOfPropertyChange(nameof(MinimalAmount));
            }
        }

        public void NavigateToEinkaufslisteView()
        {
            _eventAggregator.PublishOnCurrentThreadAsync(new NavigationEvent(typeof(ShoppinglistViewModel)));
        }

        private void FillSettings(int selectedMaterial)
        {
            if (selectedMaterial < 0) return;
            var materialToFill = Materials[selectedMaterial];
            Name = materialToFill.Name;
            Amount = materialToFill.Count.ToString();
            MinimalAmount = materialToFill.MinimalCount.ToString();
        }

        public void AddToCount()
        {
            Amount = (Convert.ToInt32(Amount) + 1).ToString();
            NotifyOfPropertyChange(() => Amount);
        }

        public void RemoveFromCount()
        {
            Amount = (Convert.ToInt32(Amount) - 1).ToString();
            NotifyOfPropertyChange(() => Amount);
        }

        public void AddToMinimal()
        {
            MinimalAmount = (Convert.ToInt32(MinimalAmount) + 1).ToString();
            NotifyOfPropertyChange(() => MinimalAmount);
        }

        public void RemoveFromMinimal()
        {
            MinimalAmount = (Convert.ToInt32(MinimalAmount) - 1).ToString();
            NotifyOfPropertyChange(() => MinimalAmount);
        }

        public void Cancel()
        {
            SelectedMaterialIndex = -1;
            Name = String.Empty;
            Amount = String.Empty;
            MinimalAmount = String.Empty;
        }

        public void Add()
        {
            if (SelectedMaterialIndex < 0)
            {
                _dataProvider.AddMaterial(
                    new Material(Name, Convert.ToInt32(Amount), Convert.ToInt32(MinimalAmount), 0));
                Materials = new ObservableCollection<Material>(_dataProvider.GetMaterials());
                NotifyOfPropertyChange(nameof(Materials));
            }
            else
            {
                Materials[SelectedMaterialIndex].Count = int.Parse(Amount);
                Materials[SelectedMaterialIndex].Name = Name;
                Materials[SelectedMaterialIndex].MinimalCount = int.Parse(MinimalAmount);
                _dataProvider.EditMaterial(Materials[SelectedMaterialIndex]);
            }
            Cancel();
        }

        public void Delete(Material material)
        {
            Materials.Remove(material);
            _dataProvider.DeleteMaterial(material.Id);
            NotifyOfPropertyChange(null);
        }
    }
}