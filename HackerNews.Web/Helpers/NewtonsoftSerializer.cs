using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackerNews.Domain;
using Newtonsoft.Json;

namespace HackerNews.Web.Helpers
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

}
