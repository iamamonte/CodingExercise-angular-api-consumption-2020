using System;

namespace HackerNews.Domain
{
    public class Story
    {
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string By { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
