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
    public partial class VersesPage : ContentPage
    {
        public string BookName { get; set; }
        public string Verses { get; set; }
        public VersesVM vm;
        public VersesPage(string book, string verse)
        {
            InitializeComponent();

            BookName = book;
            Verses = verse;

            vm = Resources["vm"] as VersesVM;
        }
        public VersesPage(string book, Chapters chapter)
        {
            InitializeComponent();

            BookName = book;
            Verses = chapter.Chapter;

            vm = Resources["vm"] as VersesVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.LoadPassage(BookName, Verses);

        }
    }
}