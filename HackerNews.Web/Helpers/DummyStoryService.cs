using HackerNews.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNews.Web.Helpers
{
    public class DummyStoryService : IStoryService
    {
        public DummyStoryService() { }
        private static string[] Titles = new[]
     {
           "Google does this",
           "Google does that",
           "Google does something atrocious",
           "Nobody cares about Google doing bad things"
        };

        private static string[] Authors = new[]
                {
           "Jimbo",
           "Slice",
           "Teddy",
           "Roosevelt"
        };

        private static string[] URLs = new[] { "https://www.google.com/"
            , "https://www.facebook.com/"
            , "https://www.twitter.com/"
            , "https://www.slashdot.org/"
            , "https://www.wikipedia.com/" };
        public IEnumerable<Story> GetNewStories(int count=500)
        {
            var rng = new Random();
            return Enumerable.Range(1, count).Select(index => new Story
            {
                By = Authors[rng.Next(Authors.Length)],
                Title = Titles[rng.Next(Titles.Length)],
                Url = URLs[rng.Next(URLs.Length)],
                Id=0
            });

        }
    }
}
