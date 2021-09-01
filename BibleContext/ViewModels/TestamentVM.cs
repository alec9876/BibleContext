using BibleContext.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BibleContext.ViewModels
{
    public class TestamentVM
    {
        public Command BackNavigationCommand { get; set; }
        public Command OldTestBooksCommand { get; set; }
        public TestamentVM()
        {
            OldTestBooksCommand = new Command(OldTestBooks);
            BackNavigationCommand = new Command(BackNavigation);
        }


        private async void OldTestBooks()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new OldTestBooksPage());
        }

        private async void BackNavigation()
        {
            await Shell.Current.GoToAsync("//intro");
        }
    }
}