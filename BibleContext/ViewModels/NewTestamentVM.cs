using System;
using System.Collections.Generic;
using System.Text;
using BibleContext.Models;
using BibleContext.Services;
using BibleContext.Views;
using MvvmHelpers;
using Xamarin.Forms;

namespace BibleContext.ViewModels
{
    public class NewTestamentVM
    {
        public ObservableRangeCollection<NewTestBooks> NewTestBooks { get; set; }
        private NewTestBooks selectedBook;
        public NewTestBooks SelectedBook
        {
            get { return selectedBook; }
            set
            {
                selectedBook = value;
                if (selectedBook != null)
                    Application.Current.MainPage.Navigation.PushAsync(new SectionChapterPage(selectedBook));
            }
        }

        public Command LegendNavigationCommand { get; set; }
        public Command BackNavigationCommand { get; set; }

        public NewTestamentVM()
        {
            LegendNavigationCommand = new Command(LegendNavigation);
            BackNavigationCommand = new Command(BackNavigation);
            NewTestBooks = new ObservableRangeCollection<NewTestBooks>();
        }

        private async void BackNavigation()
        {
            await Shell.Current.GoToAsync($"testament");
        }

        private async void LegendNavigation()
        {
            await Shell.Current.GoToAsync("otlegend");
        }

        public async void GetBooks()
        {
            var books = await Firestore.ReadNT();
            NewTestBooks.Clear();

            foreach (var book in books)
            {
                NewTestBooks.Add(book);
            }
        }
    }
}
