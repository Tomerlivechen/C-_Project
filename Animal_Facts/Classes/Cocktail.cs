using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace API_hub.Classes
{
    public class Cocktail
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("instructions")]
        public string Instructions { get; set; }
        [JsonPropertyName("ingredients")]
        public string[] Ingredients { get; set; }
    }
}
