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
    public partial class ChaptersPage : ContentPage
    {
        private ChapterVM vm;
        public OldTestBooks SelectedBook { get; set; }
        public ChaptersPage(OldTestBooks selectedBook)
        {
            InitializeComponent();

            vm = Resources["vm"] as ChapterVM;
            (Resources["vm"] as ChapterVM).SelectedBook = selectedBook;
            (Resources["vm"] as ChapterVM).BookTitle = selectedBook.BookName;
            SelectedBook = selectedBook;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.GetChapters();
        }
    }
}