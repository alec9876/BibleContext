using BibleContext.Models;
using BibleContext.Services;
using BibleContext.ViewModels;
using SQLite;
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
    public partial class OldTestBooksPage : ContentPage
    {
        private OldTestamentVM vm;
        public OldTestBooksPage()
        {
            InitializeComponent();

            vm = Resources["vm"] as OldTestamentVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.GetBooks();
        }

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();

        //    var books = await Firestore.Read();
        //    oldTestBooksList.ItemsSource = books;
        //}

    }
}