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
        public Command NewTestBooksCommand { get; set; }

        public TestamentVM()
        {
            OldTestBooksCommand = new Command(OldTestBooks);
            NewTestBooksCommand = new Command(NewTestBooks);
            BackNavigationCommand = new Command(BackNavigation);
        }


        private async void OldTestBooks()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new OldTestBooksPage());
        }

        private async void NewTestBooks()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new NewTestBooksPage());
        }

        private async void BackNavigation()
        {
            await Shell.Current.GoToAsync("//intro");
        }
    }
}