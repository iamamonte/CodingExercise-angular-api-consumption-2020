using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerNews.Domain
{
    public class StoryService : IStoryService
    {
        private readonly IHackerNewsService _hackerNewsService;
        private readonly INetCoreSerializer _netCoreSerializer;

        public StoryService(IHackerNewsService hackerNewsService, INetCoreSerializer netCoreSerializer)
        {
            _hackerNewsService = hackerNewsService;
            _netCoreSerializer = netCoreSerializer;
        }
        public IEnumerable<Story> GetNewStories(int count=500)
        {

            int storyCount = 0;
            var json = _hackerNewsService.FetchTopStories().Result;
            List<int> storyIds = _netCoreSerializer.SerializeIntegerList(json).ToList();
            List<Story> retval = new List<Story>();
            foreach (var id in storyIds)
            {

                var storyJson = _hackerNewsService.FetchItem(id).Result;
                var story = _netCoreSerializer.Serialize(storyJson);
                if (story != null)
                {
                    retval.Add(story);
                    storyCount++;
                }
                if (storyCount >= count) break;
            }
            
            return retval;
        }
    }
}
