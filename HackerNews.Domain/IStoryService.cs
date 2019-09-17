using System;
using System.Collections.Generic;
using System.Text;

namespace HackerNews.Domain
{
    /// <summary>
    /// Handles retrieving Story items from HackerNews API and exposing them as <see cref="Story"/> objects.
    /// </summary>
    public interface IStoryService
    {
        /// <summary>
        /// Retrieves the newest 500 stories
        /// </summary>
        /// <returns></returns>
        IEnumerable<Story> GetNewStories(int count=500);

    }
}
