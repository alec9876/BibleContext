using BibleContext.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BibleContext.ViewModels
{
    public class OTLegendVM
    {
        public Command BackNavigationCommand { get; set; }

        public OTLegendVM()
        {
            BackNavigationCommand = new Command(BackNavigation);
        }
        private async void BackNavigation()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
