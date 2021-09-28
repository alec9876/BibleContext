using BibleContext.Models;
using BibleContext.ViewModels;
using BibleContext.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BibleContext.Views
{
    public partial class SectionChapterPage : ContentPage
    {
        public SectionChapterPage(OldTestBooks selectedBook)
        {
            InitializeComponent();
            (Resources["vm"] as SectionChapterVM).SelectedBook = selectedBook;
            (Resources["vm"] as SectionChapterVM).BookTitle = selectedBook.BookName;
        }

        public SectionChapterPage(NewTestBooks selectedBook)
        {
            InitializeComponent();
            (Resources["vm"] as SectionChapterVM).SelectedBookNT = selectedBook;
            (Resources["vm"] as SectionChapterVM).BookTitle = selectedBook.BookName;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            //vm.GetBook(BookId);
        }

    }
}