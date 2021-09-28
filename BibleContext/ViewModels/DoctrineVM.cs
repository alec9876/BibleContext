using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BibleContext.ViewModels
{
    public class DoctrineVM
    {
        public Command BackNavigationCommand { get; set; }

        public DoctrineVM()
        {
            BackNavigationCommand = new Command(BackNavigation);
        }
        private async void BackNavigation()
        {
            await Shell.Current.GoToAsync("//intro");
        }
    }
}
