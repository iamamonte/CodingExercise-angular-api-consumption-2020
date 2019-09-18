using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HackerNews.Domain;

namespace HackerNews.Web.Controllers
{
    [Route("api/[controller]")]
    public class StoryController : Controller
    {
        private readonly IStoryService _storyService;
        private List<Story> DataStore = new List<Story>();
        public StoryController(IStoryService storyService)
        {
            _storyService = storyService;
            //hardcoded number of stories
            ResetDataStore(30);
           

        }

        private void ResetDataStore(int count)
        { 
            //TODO: place stories into cache
            DataStore = _storyService.GetNewStories(count).ToList();
        }

        /// <summary>
        /// Clears the Story objects held in memory.
        /// </summary>
        [HttpGet]
        public void Reset()
        {
            DataStore = new List<Story>();
        }

        [HttpGet("[action]")]
        public IEnumerable<Story> Stories(int count = 20)
        {
            if (DataStore.Count < count)
            {
                ResetDataStore(count);
            }
            return DataStore;
        }

        [HttpGet]
        public IEnumerable<Story> Query(int page, int results, string query = null)
        {
            return DataStore.Where(x => string.IsNullOrEmpty(query)
            || (x.Title.Contains(query, StringComparison.CurrentCultureIgnoreCase) || x.By.Contains(query, StringComparison.CurrentCultureIgnoreCase)))
                .Skip(page * results)
                .Take(results);
        }

    }
}
