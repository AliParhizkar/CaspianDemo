using Newtonsoft.Json;

namespace Caspian.UI
{
    public class SelectListItem
    {
        public SelectListItem(string value, string text)
        {
            Text = text;
            Value = value;
        }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
