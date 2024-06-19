using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace API_hub.Classes
{
    public class Drinks
    {
        public List<Drink> drinks { get; set; } = new List<Drink>();
    }
    public class Drink
    {
        [JsonPropertyName("strDrink")]
        public string Name { get; set; }
        [JsonPropertyName("strGlass")]
        public string Glass_Type { get; set; }
        [JsonPropertyName("strInstructions")]
        public string Instructions { get; set; }
        [JsonPropertyName("strDrinkThumb")]
        public string Picture_link { get; set; }
        [JsonPropertyName("strIngredient1")]
        public string Ingredient_1 { get; set; }
        [JsonPropertyName("strIngredient2")]
        public string Ingredient_2 { get; set; }
        [JsonPropertyName("strIngredient3")]
        public string Ingredient_3 { get; set; }
        [JsonPropertyName("strIngredient4")]
        public string Ingredient_4 { get; set; }
        [JsonPropertyName("strIngredient5")]
        public string Ingredient_5 { get; set; }
        [JsonPropertyName("strIngredient6")]
        public string Ingredient_6 { get; set; }
        [JsonPropertyName("strIngredient7")]
        public string Ingredient_7 { get; set; }
        [JsonPropertyName("strIngredient8")]
        public string Ingredient_8 { get; set; }
        [JsonPropertyName("strIngredient9")]
        public string Ingredient_9 { get; set; }
        [JsonPropertyName("strIngredient10")]
        public string Ingredient_10 { get; set; }
        [JsonPropertyName("strIngredient11")]
        public string Ingredient_11 { get; set; }
        [JsonPropertyName("strIngredient12")]
        public string Ingredient_12 { get; set; }
        [JsonPropertyName("strIngredient13")]
        public string Ingredient_13 { get; set; }
        [JsonPropertyName("strIngredient14")]
        public string Ingredient_14 { get; set; }
        [JsonPropertyName("strIngredient15")]
        public string Ingredient_15 { get; set; }
        [JsonPropertyName("strMeasure1")]
        public string Measurement_1 { get; set; }
        [JsonPropertyName("strMeasure2")]
        public string Measurement_2 { get; set; }
        [JsonPropertyName("strMeasure3")]
        public string Measurement_3 { get; set; }
        [JsonPropertyName("strMeasure4")]
        public string Measurement_4 { get; set; }
        [JsonPropertyName("strMeasure5")]
        public string Measurement_5 { get; set; }
        [JsonPropertyName("strMeasure6")]
        public string Measurement_6 { get; set; }
        [JsonPropertyName("strMeasure7")]
        public string Measurement_7 { get; set; }
        [JsonPropertyName("strMeasure8")]
        public string Measurement_8 { get; set; }
        [JsonPropertyName("strMeasure9")]
        public string Measurement_9 { get; set; }
        [JsonPropertyName("strMeasure10")]
        public string Measurement_10 { get; set; }
        [JsonPropertyName("strMeasure11")]
        public string Measurement_11 { get; set; }
        [JsonPropertyName("strMeasure12")]
        public string Measurement_12 { get; set; }
        [JsonPropertyName("strMeasure13")]
        public string Measurement_13 { get; set; }
        [JsonPropertyName("strMeasure14")]
        public string Measurement_14 { get; set; }
        [JsonPropertyName("strMeasure15")]
        public string Measurement_15 { get; set; }
    }
}
