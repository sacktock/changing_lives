using changing_lives.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace changing_lives.Services
{
    class ArticleStore : IDataStore<Article>
    {
        private FireBase fireBase;
        public ArticleStore()
        {
            this.fireBase = new FireBase();
        }
        public Task<bool> AddItemAsync(Article item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Article> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Article>> GetItemsAsync(bool forceRefresh = false)
        {
            return await fireBase.GetAllArticlesAsync();
        }

        public Task<bool> UpdateItemAsync(Article item)
        {
            throw new NotImplementedException();
        }
    }
}
