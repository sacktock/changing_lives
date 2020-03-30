using changing_lives.Models;
using changing_lives.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace changing_lives.ViewModels
{
    public class MessagingTabView : TabbedView
    {
        public IDataStore<Contact> DataStore => DependencyService.Get<IDataStore<Contact>>();
        public ObservableCollection<Contact> Contacts { get; set; }
        public Command LoadContactsCommand { get; set; }
        public MessagingTabView()
        {
            Title = "Messaging";
            Contacts = new ObservableCollection<Contact>();
            LoadContactsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            // code here to load in messages on instantiation?
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            Debug.Print("busy");

            try
            {
                var contacts = await DataStore.GetItemsAsync(true);
                Contacts.Clear();
                foreach (var contact in contacts)
                {
                    Contacts.Add(contact);
                }
                // get messages from datastore

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
