using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace API_hub.Classes
{
    public class Animal
    {
        public string name { get; set; }
        public Taxonomy taxonomy { get; set; }
        public string[] locations { get; set; }
        public Characteristics characteristics { get; set; }
    }
    public class Taxonomy
    {
        public string Kingdom { get; set; } = null;
        public string Phylum { get; set; } = null;
        [JsonPropertyName("class")]
        public string Class { get; set; } = null;
        public string Order { get; set; } = null;
        public string Family { get; set; } = null;
        public string Genus { get; set; } = null;
        public string Scientific_name { get; set; } = null;
    }
    public class Characteristics
    {
        public string pray { get; set; } = null;
        public string name_of_young { get; set; } = null;
        public string group_behavior { get; set; } = null;
        public string estimated_population_size { get; set; } = null;
        public string biggest_threat { get; set; } = null;
        public string most_distinctive_feature { get; set; } = null;
        public string gestation_period { get; set; } = null;
        public string habitat { get; set; } = null;
        public string diet { get; set; } = null;
        public string average_litter_size { get; set; } = null;
        public string lifestyle { get; set; } = null;
        public string common_name { get; set; } = null;
        public string number_of_species { get; set; } = null;
        public string location { get; set; } = null;
        public string slogan { get; set; } = null;
        public string group { get; set; } = null;
        public string color { get; set; } = null;
        public string skin_type { get; set; } = null;
        public string top_speed { get; set; } = null;
        public string lifespan { get; set; } = null;
        public string weight { get; set; } = null;
        public string height { get; set; } = null;
        public string age_of_sexual_maturity { get; set; } = null;
        public string age_of_weaning { get; set; } = null;
        public string favorite_food { get; set; } = null;
        public string type { get; set; } = null;
        public string temperament { get; set; } = null;
        public string biggerst_threat { get; set; } = null;
        public string length { get; set; } = null;
        public string optimum_ph_level { get; set; } = null;
        public string migratory { get; set; } = null;
        public string wingspan { get; set; } = null;
        [JsonPropertyName("other_name(s)")]
        public string other_names { get; set; } = null;
        public string age_of_molting { get; set; } = null;
        public string nesting_location { get; set; } = null;
        public string water_type { get; set; } = null;
    }
}
