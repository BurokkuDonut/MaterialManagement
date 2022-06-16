using System;

namespace MaterialManagement.ViewModels
{
    public class NavigationEvent
    {
        public NavigationEvent(Type navigateTo)
        {
            NavigateTo = navigateTo.Name;
        }

        public string NavigateTo { get; set; }
    }
}