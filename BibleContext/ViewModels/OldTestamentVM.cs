using BibleContext.Models;
using BibleContext.Services;
using BibleContext.Views;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace BibleContext.ViewModels
{
    public class OldTestamentVM : ObservableObject
    {
        public ObservableRangeCollection<OldTestBooks> OldTestBooks { get; set; }
        public ObservableRangeCollection<OldTestBooks> AllOldTestBooks { get; set; }
        public ObservableRangeCollection<string> FilterOptions { get; }
        string selectedFilter = "All";
        public string SelectedFilter
        {
            get => selectedFilter;
            set
            {
                if (SetProperty(ref selectedFilter, value))
                    FilterItems();
            }
        }

        private OldTestBooks selectedBook;
        public OldTestBooks SelectedBook
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


        public OldTestamentVM()
        {
            LegendNavigationCommand = new Command(LegendNavigation);
            BackNavigationCommand = new Command(BackNavigation);
            OldTestBooks = new ObservableRangeCollection<OldTestBooks>();
            AllOldTestBooks = new ObservableRangeCollection<OldTestBooks>();
            FilterOptions = new ObservableRangeCollection<string>
            {
               "All", "Law", "Narrative", "Poetic", "Prophetic", "Wisdom"
            };
        }

        private async void BackNavigation()
        {
            await Shell.Current.GoToAsync($"home");
        }

        private async void LegendNavigation()
        {
            await Shell.Current.GoToAsync("otlegend");
        }

        public async void GetBooks()
        {
            var books = await Firestore.Read();
            AllOldTestBooks.ReplaceRange(books);
            FilterItems();
            OldTestBooks.Clear();

            foreach (var book in books)
            {
                OldTestBooks.Add(book);
            }
        }

        void FilterItems()
        {
            OldTestBooks.ReplaceRange(AllOldTestBooks.Where(a => a.Genre == SelectedFilter || SelectedFilter == "All"));
        }

    }
}
