using System;
using System.Collections.Generic;
using System.Text;

namespace HackerNews.Domain
{
    /// <summary>
    /// Abstraction of a Json Serializer
    /// </summary>
    public interface INetCoreSerializer
    {
        /// <summary>
        /// Deserializes a string into a <see cref="Story"/>.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        Story Serialize(string json);

        IEnumerable<int> SerializeIntegerList(string json);
    }
}
