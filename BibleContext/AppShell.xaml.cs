using BibleContext.Views;
using Xamarin.Forms;

namespace BibleContext
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Registering page for navigation
            Routing.RegisterRoute(nameof(IntroPage), typeof(IntroPage));
            Routing.RegisterRoute("intro/home", typeof(HomePage));
            Routing.RegisterRoute("intro/home/oldtest", typeof(OldTestBooksPage));
            Routing.RegisterRoute(nameof(SectionChapterPage), typeof(SectionChapterPage));
            Routing.RegisterRoute(nameof(SectionsPage), typeof(SectionsPage));
            Routing.RegisterRoute("intro/home/oldtest/otlegend", typeof(OTLegendPage));
            Routing.RegisterRoute(nameof(VersesPage), typeof(VersesPage));

        }
    }
}
