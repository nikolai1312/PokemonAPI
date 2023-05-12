using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAPI.Domain.Models
{
    public class Pokemon
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("height")]
        public double? Height { get; set; }
        
        [JsonProperty("weight")]
        public double? Weight { get; set; }

    }
}
