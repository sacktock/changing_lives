using changing_lives.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace changing_lives.Services
{
    class ContactStore : IDataStore<Contact>
    {
        private FireBase fireBase;

        public ContactStore()
        {
            this.fireBase = new FireBase();
        }
        public Task<bool> AddItemAsync(Contact item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Contact>> GetItemsAsync(bool forceRefresh = false)
        {
            return await fireBase.GetAllContactsAsync();
        }

        public Task<bool> UpdateItemAsync(Contact item)
        {
            throw new NotImplementedException();
        }
    }
}
