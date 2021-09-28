using BibleContext.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BibleContext.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IntroPage : ContentPage
    {
        public IntroPage()
        {
            InitializeComponent();
        }

        private async void Bible_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//intro/testament");
        }

        private async void Doctrine_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//intro/doctrine");
        }

        private void Data_Clicked(object sender, EventArgs e)
        {
            Firestore.Insert();
        }
    }
}