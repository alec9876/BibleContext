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
            Routing.RegisterRoute("intro/testament", typeof(TestamentPage));
            Routing.RegisterRoute("intro/testament/oldtest", typeof(OldTestBooksPage));
            Routing.RegisterRoute("intro/testament/newtest", typeof(NewTestBooksPage));
            Routing.RegisterRoute(nameof(SectionChapterPage), typeof(SectionChapterPage));
            Routing.RegisterRoute(nameof(SectionsPage), typeof(SectionsPage));
            Routing.RegisterRoute("intro/testament/oldtest/otlegend", typeof(OTLegendPage));
            Routing.RegisterRoute(nameof(VersesPage), typeof(VersesPage));
            Routing.RegisterRoute("intro/doctrine", typeof(DoctrinePage));

        }
    }
}
