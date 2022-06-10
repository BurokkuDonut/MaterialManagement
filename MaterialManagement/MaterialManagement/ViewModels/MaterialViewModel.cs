using System;
using System.Collections.Generic;
using Caliburn.Micro;
using MaterialManagement.Models;

namespace MaterialManagement.ViewModels
{
    public class MaterialViewModel : Screen
    {
        private readonly IDataProvider _dataProvider;
        private readonly EventAggregator _eventAggregator;
        private string _amount;
        private List<Material> _materials;
        private string _minimalAmount;
        private string _name;
        private int _selectedMaterialIndex;

        public MaterialViewModel(EventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _dataProvider = new DataProvider();
            Materials = _dataProvider.GetMaterials();
        }

        public List<Material> Materials
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
                NotifyOfPropertyChange(nameof(Name));
            }
        }

        public string Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                NotifyOfPropertyChange(nameof(Amount));
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
            var materialToFill = Materials[selectedMaterial];
            Name = materialToFill.Name;
            Amount = materialToFill.Count.ToString();
            MinimalAmount = materialToFill.MinimalCount.ToString();
        }

        public void AddToCount()
        {
            Materials[_selectedMaterialIndex].Count += 1;
            NotifyOfPropertyChange(nameof(Amount));
        }

        public void RemoveFromCount()
        {
            Materials[_selectedMaterialIndex].Count -= 1;
            NotifyOfPropertyChange(nameof(Amount));
        }
    }

    public class NavigationEvent
    {
        public NavigationEvent(Type navigateTo)
        {
            NavigateTo = navigateTo.Name;
        }

        public string NavigateTo { get; set; }
    }
}