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
    class HomeTabView : TabbedView
    {
        public IDataStore<Article> DataStore => DependencyService.Get<IDataStore<Article>>();
        public ObservableCollection<Article> Articles { get; set; }
        public Command LoadArticlesCommand { get; set; }
        public HomeTabView()
        {
            Title = "Changing-Lives Feed";
            Articles = new ObservableCollection<Article>();
            LoadArticlesCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            Debug.Print("busy");

            try
            {
                var articles = await DataStore.GetItemsAsync(true);
                Articles.Clear();
                foreach (var article in articles)
                {
                    Articles.Add(article);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
           
            IsBusy = false;

        }
    }
}
