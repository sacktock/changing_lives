using changing_lives.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace changing_lives.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        HomeTabView viewModel;

        public HomePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new HomeTabView();
        }

        protected override void OnAppearing()
        {
            // load messages when the activity first appears
            base.OnAppearing();

            //load from the messaging tab view
            if (viewModel.Articles.Count == 0)
            {
                viewModel.LoadArticlesCommand.Execute(null);
            }

        }

        private Boolean IsValidUri(String uri)
        {
            try
            {
                new Uri(uri);
                return true;
            }
            catch
            {
                return false;
            }
        }
        async void OnButtonClicked(object sender, EventArgs args)
        {
            var button = (Button)sender;
            var text = button.Text;
            await Browser.OpenAsync(new Uri(text), BrowserLaunchMode.SystemPreferred);
        }

        public ICommand ClickCommand => new Command<string>(async (url) =>
        {
            try
            {
                if (!string.IsNullOrEmpty(url))
                {
                    if (!url.Trim().StartsWith("http", StringComparison.OrdinalIgnoreCase))
                    {
                        url = "http://" + url;
                    }
                    if (IsValidUri(url))
                    {
                        await Browser.OpenAsync(new Uri(url), BrowserLaunchMode.SystemPreferred);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        });

        private void ItemsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}