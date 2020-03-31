using changing_lives.Services;
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
    public partial class LoginPage : ContentPage
    {
        private string userCode;
        private FireBase fbase;

        public LoginPage()
        {
            InitializeComponent();
            userCode = "";
            fbase = new FireBase();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            int authCode = await Authenticate();
            if (authCode == 1) 
            {
                await Navigation.PushModalAsync(new MainPage()); // navigate to the main page
            }
            else if (authCode == 0)
            {
                await DisplayAlert("Authentication Error", "The user code you entered was not recognised", "Ok");
            }
            else if (authCode == -1)
            {
                await DisplayAlert("Authentication Error", "Failed to contact the web server - please make sure you have internet", "Ok");
            }
            else
            {
                await DisplayAlert("Authentication Error", "Unexpected error occured when authenticating", "Ok");
            }
        }

        private async Task<int> Authenticate()
        {
            return await fbase.authenticate(userCode);
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.userCode = e.NewTextValue;
        }
    }
}