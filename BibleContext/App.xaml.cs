using BibleContext.Services;
using BibleContext.Views;
using Xamarin.Forms;

namespace BibleContext
{
    public partial class App : Application
    {
        public static string databaseLocation = string.Empty;

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        public App(string databasePath)
        {
            InitializeComponent();

            MainPage = new AppShell();
            databaseLocation = databasePath;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
