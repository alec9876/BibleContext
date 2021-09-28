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
    public class SectionVM : INotifyPropertyChanged
    {
        public ObservableCollection<Section> Sections { get; set; }
        private Section _verse { get; set; }
        public Section Verse
        {
            get { return _verse; }
            set
            {
                _verse = value;
                if (_verse != null)
                    Application.Current.MainPage.Navigation.PushAsync(new VersesPage(SelectedBook.BookName,_verse.ToString()));
            }
        }
        public OldTestBooks SelectedBook { get; set; }
        public Command BackNavigationCommand { get; set; }
        public Command LegendNavigationCommand { get; set; }
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

        public SectionVM()
        {
            LegendNavigationCommand = new Command(LegendNavigation);
            BackNavigationCommand = new Command(BackNavigation);
            Sections = new ObservableCollection<Section>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string _value)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_value));
        }

        private async void BackNavigation()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SectionChapterPage(SelectedBook));

        }

        private async void LegendNavigation()
        {
            await Shell.Current.GoToAsync("otlegend");
        }


        public async void GetSections()
        {
            Sections.Clear();
            var sections = await Firestore.GetSectionsOT(SelectedBook.Id);

            foreach (var sec in sections)
            {
                Sections.Add(sec);
            }
        }
    }
}
