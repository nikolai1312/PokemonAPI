using Newtonsoft.Json;
using PokemonAPI.Controllers;
using PokemonAPI.Domain.Models;
using RestSharp;
using System.Text.Json;
using System.Text.Json.Serialization;

PokeController poke =  new PokeController();
poke.StartMenu();
poke.MenuOptions();
