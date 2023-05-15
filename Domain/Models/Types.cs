using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAPI.Domain.Models
{
    public class Types
    {
        public TypeName type { get; set; }
        public int slot { get; set; }
    }
}
