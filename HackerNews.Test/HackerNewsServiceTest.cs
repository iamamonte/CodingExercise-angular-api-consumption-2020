using NUnit.Framework;
using HackerNews.Domain;

namespace Tests
{
    [TestFixture]
    public class HackerNewsServiceTests
    {
        private IHackerNewsService _service;
        private const string NULLRESPONSE = "null\n";
        [SetUp]
        public void Setup()
        {
            _service = new HackerNewsService();
        }

        [Test]
        public void Can_fetch_top_stories()
        {
            var topStories = _service.FetchTopStories().Result;
            Assert.IsFalse(string.IsNullOrEmpty(topStories));
            Assert.AreNotEqual(NULLRESPONSE, topStories);
        }

        [TestCase(1)]
        //[TestCase(-1)]
        [Test]
        public void Can_fetch_item(int id)
        {
            var item = _service.FetchItem(id).Result;
            Assert.IsFalse(string.IsNullOrEmpty(item));
            Assert.AreNotEqual(NULLRESPONSE, item);
        }

        [TestCase("justin")]
        //[TestCase("09u21bfsdef-FAKE")]
        [Test]
        public void Can_fetch_user(string id)
        {
            var user = _service.FetchUser(id).Result;
            Assert.IsFalse(string.IsNullOrEmpty(user));
            Assert.AreNotEqual(NULLRESPONSE, user);
        }
    }
}