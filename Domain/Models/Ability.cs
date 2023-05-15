using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAPI.Domain.Models
{
    public class Ability
    {
        public AbilitiesName ability { get; set; }
        public bool is_hidden { get; set; }
    }
}
