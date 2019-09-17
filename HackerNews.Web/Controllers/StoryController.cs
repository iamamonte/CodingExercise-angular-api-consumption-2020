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
            //TODO: place stories into cache
            DataStore = _storyService.GetNewStories().ToList();
            
        }

     

        

        [HttpGet("[action]")]
        public IEnumerable<Story> Stories()
        {

            return DataStore;
        }

    }
}
