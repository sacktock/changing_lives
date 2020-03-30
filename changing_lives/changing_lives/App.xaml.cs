using changing_lives.Services;
using changing_lives.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace changing_lives
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<ArticleStore>();
            DependencyService.Register<ContactStore>();
            MainPage = new LoginPage();
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
