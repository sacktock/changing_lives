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
            try 
            {
                if (IsValidUri(text))
                {
                    await Browser.OpenAsync(new Uri(text), BrowserLaunchMode.SystemPreferred);
                }
                else 
                {
                    return;
                }
            } 
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await DisplayAlert("Error", "Could not follow the link", "Ok");
                return;
            }
            
        }

        private void ItemsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}