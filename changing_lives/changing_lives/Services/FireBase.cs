using changing_lives.Models;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace changing_lives.Services
{
    public class FireBase
    {
        FirebaseClient firebase;

        public FireBase()
        {
            firebase = new FirebaseClient("https://changing-lives-database-1a9c6.firebaseio.com/");
            // replace the hyperlink above with the hyperlink of your database
        }

        public async Task<int> authenticate(string userCode)
        {
            try
            {
                var items = await GetAllUsercodesAsync();

                foreach (var item in items)
                {
                    if (item.code.Equals(userCode))
                    {
                        return 1;
                    }
                }
                return 0;

            }
            catch
            {
                return -1;
            }
        }

        public async Task<List<Usercode>> GetAllUsercodesAsync()
        {
            return (await firebase
              .Child("Usercodes")
              .OnceAsync<Usercode>()).Select(item => new Usercode
              {
                  code = item.Object.code
              }).ToList();
        }

        public async Task<List<Contact>> GetAllContactsAsync()
        {

            return (await firebase
              .Child("Contacts")
              .OnceAsync<Contact>()).Select(item => new Contact
              {
                  Name = item.Object.Name,
                  Mobile_Number = item.Object.Mobile_Number,
                  Desc = item.Object.Desc
              }).ToList();
        }

        public async Task<List<Article>> GetAllArticlesAsync()
        {

            return (await firebase
              .Child("Articles")
              .OnceAsync<Article>()).Select(item => new Article
              {
                  Title = item.Object.Title,
                  Body = item.Object.Body,
                  Timestamp = item.Object.Timestamp,
                  link = item.Object.link,
                  src = item.Object.src
              }).ToList();
        }

    }
}
