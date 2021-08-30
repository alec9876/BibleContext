using BibleContext.Models;
using BibleContext.Services;
using BibleContext.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace BibleContext.ViewModels
{
    public class ChapterVM : INotifyPropertyChanged
    {
        public ObservableCollection<Chapters> Chapters { get; set; }
        public Command BackNavigationCommand { get; set; }
        //public Command LegendNavigationCommand { get; set; }
        private Chapters _chapter { get; set; }
        public Chapters Chapter
        {
            get { return _chapter; }
            set
            {
                _chapter = value;
                if (_chapter != null)
                    Application.Current.MainPage.Navigation.PushAsync(new VersesPage(SelectedBook.BookName, _chapter));
            }
        }
        public OldTestBooks SelectedBook { get; set; }
        private string _bookTitle { get; set; }
        public string BookTitle
        {
            get { return _bookTitle; }
            set
            {
                _bookTitle = value;
                OnPropertyChanged("BookTitle");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string _bookTitle)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_bookTitle));
        }

        public ChapterVM()
        {
            //LegendNavigationCommand = new Command(LegendNavigation);
            BackNavigationCommand = new Command(BackNavigation);
            Chapters = new ObservableCollection<Chapters>();
        }

        private async void BackNavigation()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SectionChapterPage(SelectedBook));

        }

        //private async void LegendNavigation()
        //{
        //    await Shell.Current.GoToAsync("otlegend");
        //}

        public async void GetChapters()
        {
            Chapters.Clear();
            var chapters = await Firestore.GetChapters(SelectedBook.Id);

            foreach (var chap in chapters)
            {
                Chapters.Add(chap);
            }
        }
    }
}
