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
            if (authCode == 1) // this authentication is good enough for the prototype
            {
                // get the user account from the database
                //UserAccount userAccount = new UserAccount{id = 0, email = "alex.w.goodall@gmail.com", first_name="Alex", second_name="Goodall", date_of_birth="30/09/1999", mobile_number="+447845440606", photo_link="" ,link="https://github.com/sacktock", is_moderator=true };
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
            //return true;
            return await fbase.authenticate(userCode);
            // check if email and password are in the database
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.userCode = e.NewTextValue;
        }
    }
}