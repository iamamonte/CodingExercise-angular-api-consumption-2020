using HackerNews.Domain;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerNews.Test
{

    public class NewtonsoftSerializer : INetCoreSerializer
    {
        public Story Serialize(string json)
        {
            return JsonConvert.DeserializeObject<Story>(json);
            
        }

        public IEnumerable<int> SerializeIntegerList(string json)
        {
            return JsonConvert.DeserializeObject<List<int>>(json);
        }
    }

    [TestFixture]
    public class StoryServiceTest
    {
        private IStoryService _storyService;

        [SetUp]
        public void SetUp()
        {
            _storyService = new StoryService(new HackerNewsService(), new NewtonsoftSerializer());
        }

        [Test]
        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        //[TestCase(500)]
        public void Can_get_stories(int count)
        {
            var stories = _storyService.GetNewStories(count);
            Assert.AreEqual(count, stories.Count());
        }
    }
}
