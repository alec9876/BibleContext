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
                    Application.Current.MainPage.Navigation.PushAsync(new VersesPage(SelectedBook.BookName,_verse));
            }
        }
        public OldTestBooks SelectedBook { get; set; }
        public Command BackNavigationCommand { get; set; }
        public Command LegendNavigationCommand { get; set; }
        public Command VersesNavigationCommand { get; set; }
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
            //VersesNavigationCommand = new Command((arg) =>
            //{
            //    VersesNavigation(arg);
            //});
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string _bookTitle)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_bookTitle));
        }

        private async void BackNavigation()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SectionChapterPage(SelectedBook));

        }

        private async void LegendNavigation()
        {
            await Shell.Current.GoToAsync("otlegend");
        }

        //private async void VersesNavigation(object Verse)
        //{
        //   // await Shell.Current.GoToAsync($"{nameof(VersesPage)}?Passage={BookTitle}+{Verse}");
        //}

        public async void GetSections()
        {
            Sections.Clear();
            var sections = await Firestore.GetSections(SelectedBook.Id);

            foreach (var sec in sections)
            {
                Sections.Add(sec);
            }
        }
    }
}
