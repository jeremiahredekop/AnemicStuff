using Newtonsoft.Json.Linq;

namespace anemicEvents.api
{
    public class SaveModel
    {
        public string EntityName { get; set; }
        public JObject Data { get; set; }
    }
}