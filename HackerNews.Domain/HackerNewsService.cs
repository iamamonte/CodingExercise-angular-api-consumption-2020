using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HackerNews.Domain
{
    public class HackerNewsService : IHackerNewsService
    {
        private HttpClient _client = new HttpClient(); 
        private readonly string _apiBase = "https://hacker-news.firebaseio.com/v0/";
        private readonly string _printPretty = ".json?print=pretty";
        public HackerNewsService()
        {
            _client.BaseAddress = new Uri(_apiBase);
        }
        public Task<string> FetchTopStories()
        {
            return _client.GetAsync($"newstories{_printPretty}").Result.Content.ReadAsStringAsync();
        }

        public Task<string> FetchItem(int id)
        {
            return  _client.GetAsync($"item/{id}{_printPretty}").Result.Content.ReadAsStringAsync();
            
        }

        public Task<string> FetchUser(string id)
        {
            return  _client.GetAsync($"user/{id}{_printPretty}").Result.Content.ReadAsStringAsync();
            
        }
    }
}