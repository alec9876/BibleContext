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
    public partial class OutlinePage : ContentPage
    {

        private OutlineVM vm;
        public NewTestBooks SelectedBook { get; set; }

        public OutlinePage(NewTestBooks selectedBook)
        {
            InitializeComponent();

            vm = Resources["vm"] as OutlineVM;
            (Resources["vm"] as OutlineVM).SelectedBook = selectedBook;
            (Resources["vm"] as OutlineVM).BookTitle = selectedBook.BookName;
            SelectedBook = selectedBook;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.GetSections();
        }

        private void Slide_Tapped(object sender, EventArgs e)
        {
            if(vm.prevVisible)
            {
                //vm.prevVisible = false;
                return;
            }
            else if(vm.isVisible)
            {
                slideFrame.TranslateTo(slideFrame.TranslationX - 100, 0);
            }
            else
            {
                slideFrame.TranslateTo(slideFrame.TranslationX + 100, 0);
            }
        }
    }
}