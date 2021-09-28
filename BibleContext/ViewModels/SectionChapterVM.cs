using BibleContext.Models;
using BibleContext.Services;
using BibleContext.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BibleContext.ViewModels
{
    
    public class SectionChapterVM : INotifyPropertyChanged
    {
        public Command SectionsNavCommand { get; set; }
        public Command ChaptersNavCommand { get; set; }
        public Command DoctrineNavCommand { get; set; }
        public Command BackNavigationCommand { get; set; }
        public OldTestBooks SelectedBook { get; set; }
        public NewTestBooks SelectedBookNT { get; set; }

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

        

        public SectionChapterVM()
        {
            BackNavigationCommand = new Command(BackNavigation);
            SectionsNavCommand = new Command(Section);
            ChaptersNavCommand = new Command(Chapters);
            DoctrineNavCommand = new Command(Doctrine);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string bookTitle)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(bookTitle));
        }

        private async void BackNavigation()
        {
            await Shell.Current.GoToAsync($"oldtest");
        }

        private async void Section()
        {
            if(SelectedBook != null)
            {
                await App.Current.MainPage.Navigation.PushAsync(new SectionsPage(SelectedBook));
            }
            else
            {
                await App.Current.MainPage.Navigation.PushAsync(new OutlinePage(SelectedBookNT));
            }
        }

        private async void Chapters()
        {
            await App.Current.MainPage.Navigation.PushAsync(new ChaptersPage(SelectedBook));
        }
        
        private async void Doctrine()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SectionsPage(SelectedBook));
        }

    }
}
