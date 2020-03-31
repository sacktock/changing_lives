using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace changing_lives.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            NavigationPage homePage = new NavigationPage(new HomePage());
            homePage.IconImageSource = ImageSource.FromResource("changing_lives.Images.baseline_rss_feed_black_48.png");
            homePage.Title = "Home";

            NavigationPage cvPage = new NavigationPage(new CVPage());
            cvPage.IconImageSource = ImageSource.FromResource("changing_lives.Images.baseline_help_black_48.png");
            cvPage.Title = "CV Helpcenter";

            NavigationPage msgPage = new NavigationPage(new MessagingPage());
            msgPage.IconImageSource = ImageSource.FromResource("changing_lives.Images.baseline_chat_bubble_black_48.png");
            msgPage.Title = "Messaging";

            Children.Add(homePage);
            Children.Add(cvPage);
            Children.Add(msgPage);
        }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }
    }
}