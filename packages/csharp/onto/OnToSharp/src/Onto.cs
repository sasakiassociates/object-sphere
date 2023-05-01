using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Stratosphere {

    public static class Onto {

        public static T? Deserialize<T>(string json) {
            // First child is the root node itself, second child is the root node's data.
            JToken root = JObject.Parse(json).Children().ToList()[0].Children().ToList()[0];

            return root.ToObject<T>();
        }

        public static string Serialize<T>(T obj) {
            var root = new JObject();

            if (obj != null) {
                
                var jo = JObject.FromObject(obj);

                if (jo.HasValues) {
                    root.Add(typeof(T).Name, jo);
                }
            }

            return root.ToString(Formatting.Indented);
        }

    }

}
