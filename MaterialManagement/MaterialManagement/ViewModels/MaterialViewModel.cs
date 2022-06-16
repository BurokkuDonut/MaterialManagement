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
            SelectedMaterialIndex = -1;
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
            if (selectedMaterial < 0) return;
            var materialToFill = Materials[selectedMaterial];
            Name = materialToFill.Name;
            Amount = materialToFill.Count.ToString();
            MinimalAmount = materialToFill.MinimalCount.ToString();
        }

        public void AddToCount()
        {
            Materials[_selectedMaterialIndex].Count += 1;
            NotifyOfPropertyChange(() => Amount);
        }

        public void RemoveFromCount()
        {
            Materials[_selectedMaterialIndex].Count -= 1;
            NotifyOfPropertyChange(() => Amount);
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
            }
            else
            {
                Materials[SelectedMaterialIndex].Count = int.Parse(Amount);
                Materials[SelectedMaterialIndex].Name = Name;
                Materials[SelectedMaterialIndex].MinimalCount = int.Parse(MinimalAmount);
                _dataProvider.EditMaterial(Materials[SelectedMaterialIndex]);
            }
        }
    }
}