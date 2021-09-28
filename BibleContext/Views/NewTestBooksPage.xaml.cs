using BibleContext.ViewModels;
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
    public partial class NewTestBooksPage : ContentPage
    {
        private NewTestamentVM vm;
        public NewTestBooksPage()
        {
            InitializeComponent();

            vm = Resources["vm"] as NewTestamentVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.GetBooks();
        }
    }
}