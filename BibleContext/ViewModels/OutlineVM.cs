using BibleContext.Models;
using BibleContext.Services;
using BibleContext.Views;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace BibleContext.ViewModels
{
    public class OutlineVM : INotifyPropertyChanged
    {
        private Section _oldSection;
        public bool isVisible;
        public bool prevVisible;
        public ObservableCollection<Section> Sections { get; set; }
        public ObservableCollection<SubSection> SubSections { get; set; }
        public NewTestBooks SelectedBook { get; set; }
        public Command<Section> SubSectionNaviationCommand { get; set; }
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

        public OutlineVM()
        {
            VersesNavigationCommand = new Command<SubSection>(VersesNavigation);
            SubSectionNaviationCommand = new Command<Section>(SubSectionNavigation);
            LegendNavigationCommand = new Command(LegendNavigation);
            BackNavigationCommand = new Command(BackNavigation);
            Sections = new ObservableCollection<Section>();
            SubSections = new ObservableCollection<SubSection>();
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

        private async void VersesNavigation(SubSection subSection)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new VersesPage(SelectedBook.BookName, subSection.Verses));
        }

        private async void SubSectionNavigation(Section section)
        {
            if (_oldSection == section)
            {
                // click twice to hide subsections
                isVisible = !isVisible;
                if(!isVisible)
                {
                    prevVisible = false;
                    SubSections.Clear();
                    if(section.Count != null)
                    {
                        foreach (var item in section.Count)
                        {
                            item.SubColor = "Blue";
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new VersesPage(SelectedBook.BookName, section.Verses));
                    }
                }
                else
                {
                    SubSections.Clear();
                    prevVisible = false;
                    if (section.Count != null)
                    {
                        foreach (var item in section.Count)
                        {
                            item.SubColor = "Orange";
                        }

                        await GetSubSections(SelectedBook.Id, section.Id);
                    }
                    else
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new VersesPage(SelectedBook.BookName, section.Verses));
                    }

                }
            }
            else
            {
                if (_oldSection != null)
                {
                    if(isVisible)
                    {
                        prevVisible = true;
                    }
                    else
                    {
                        prevVisible = false;
                    }

                    isVisible = true;

                    if (_oldSection.Count != null)
                    {
                        foreach (var item in _oldSection.Count)
                        {
                            item.SubColor = "Blue";
                        }
                    }

                    if (section.Count != null)
                    {
                        foreach (var item in section.Count)
                        {
                            item.SubColor = "Orange";
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new VersesPage(SelectedBook.BookName, section.Verses));
                    }

                    SubSections.Clear();
                    await GetSubSections(SelectedBook.Id, section.Id);
                }
                else
                {
                    // show selected subsection item
                    isVisible = true;

                    if(section.Count != null)
                    {
                        foreach (var item in section.Count)
                        {
                            item.SubColor = "Orange";
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new VersesPage(SelectedBook.BookName, section.Verses));
                    }

                    await GetSubSections(SelectedBook.Id, section.Id);
                }
            }

            UpdateSection(section, _oldSection);

            _oldSection = section;
        }

        private void UpdateSection(Section section, Section oldSection)
        {
            var index = Sections.IndexOf(section);
            Sections.Remove(section);
            Sections.Insert(index, section);

            if (oldSection != null)
            {
                var oldIndex = Sections.IndexOf(oldSection);
                if(oldIndex > -1)
                {
                    Sections.Remove(oldSection);
                    Sections.Insert(oldIndex, oldSection);
                }
            }
        }

        public async void GetSections()
        {
            //Sections.Clear();
            //SubSections.Clear();
            var sections = await Firestore.GetSectionsNT(SelectedBook.Id);
            
            foreach (var sec in sections)
            {
                Sections.Add(sec);

                if (sec.SubSectionCount > 0)
                {
                    sec.Count = new List<SubCount>();
                    for (var i = 0; i < sec.SubSectionCount; i++)
                    {
                        SubCount subCount = new SubCount()
                        {
                            SectionId = sec.Id,
                            SubColor = "Blue"
                        };

                        sec.Count.Add(subCount);
                    }
                }
            }
        }

        public async Task GetSubSections(string bookId, string sectionId)
        {
            var subSections = await Firestore.GetSubSectionsNT(bookId, sectionId);

            foreach(var item in subSections)
            {
                SubSections.Add(item);
            }

            return;
        }


    }
}
