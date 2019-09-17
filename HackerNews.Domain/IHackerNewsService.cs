using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackerNews.Domain
{
    /// <summary>
    /// Handles direct interfacing with HackerNews API
    /// </summary>
    public interface IHackerNewsService
    {
        /// <summary>
        /// Retrieves raw json of top 500 stories from HackerNews API
        /// </summary>
        /// <returns></returns>
        Task<string> FetchTopStories();

        /// <summary>
        /// Gets raw json for an item from HackerNews API. Stories are Items.
        /// </summary>
        /// <param name="id">HackerNews item Id</param>
        /// <returns></returns>
        Task<string> FetchItem(int id);

        /// <summary>
        /// Gets raw json for a User item from HackerNews API
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<string> FetchUser(string id);
    }
}