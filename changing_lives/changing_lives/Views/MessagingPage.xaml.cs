using changing_lives.Models;
using changing_lives.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace changing_lives.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagingPage : ContentPage
    {
        MessagingTabView viewModel;
        public MessagingPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MessagingTabView();
        }

        async void NewItem_Clicked(object sender, EventArgs e)
        {
            await SendSms("", new string[] { });
            // send to new message page
        }

        protected override void OnAppearing()
        {
            // load messages when the activity first appears
            base.OnAppearing();

            //load from the messaging tab view
            if (viewModel.Contacts.Count == 0)
                viewModel.LoadContactsCommand.Execute(null);
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ItemsListView.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                viewModel.LoadContactsCommand.Execute(null);
                ItemsListView.ItemsSource = viewModel.Contacts;
            }
            else
            {
                ItemsListView.ItemsSource = viewModel.Contacts.Where(i => i.Name.ToLower().Contains(e.NewTextValue.ToLower()));
            }

            ItemsListView.EndRefresh();
        }

        async private void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            // handle item click
            try
            {
                string[] recipients = { ((Contact)e.Item).Mobile_Number };
                await SendSms("", recipients);
            }
            catch
            {
                // await DisplayAlert("Item Error", "Failed to open chat", "OK");
            }


            ((ListView)sender).SelectedItem = null;
        }

        private async Task SendSms(string messageText, string[] recipients)
        {
            try
            {
                var message = new SmsMessage(messageText, recipients);
                await Sms.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException)
            {
                await DisplayAlert("Device Error", "Sms not supported on this device", "Ok");
            }
            catch
            {
                await DisplayAlert("Unknown Error", "Failed to send Sms", "Ok");

            }
        }
    }
}