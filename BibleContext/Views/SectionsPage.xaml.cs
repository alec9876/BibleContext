using BibleContext.Models;
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
    public partial class SectionsPage : ContentPage
    {
        private SectionVM vm;
        public OldTestBooks SelectedBook { get; set; }
        public SectionsPage(OldTestBooks selectedBook)
        {
            InitializeComponent();

            vm = Resources["vm"] as SectionVM;
            (Resources["vm"] as SectionVM).SelectedBook = selectedBook;
            (Resources["vm"] as SectionVM).BookTitle = selectedBook.BookName;
            SelectedBook = selectedBook;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.GetSections();
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new SectionChapterPage(SelectedBook));
        }
    }
}