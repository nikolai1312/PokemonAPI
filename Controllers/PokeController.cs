using Newtonsoft.Json;
using PokemonAPI.Domain.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAPI.Controllers
{
    public class PokeController
    {
        public PokeController() { }

        //---------------------------------------- API DO POKEMON -----------------------------------------------

        // --------------------------------------- MOSTRANDO DADOS API -------------------------------------------

        public void ShowPoke()
        {
            Console.Write("Search the pokemon name: ");
            string result = Console.ReadLine().ToLower();
            try
            {
                var pokeString = GetPokemon(result);
                var poke = JsonConvert.DeserializeObject<Pokemon>(pokeString);
                Console.WriteLine($"Pokemon Name: {poke.Name}");
                Console.WriteLine($"Pokemon Height (decimeter): {poke.Height}");
                Console.WriteLine($"Pokemon Weight (hectogram): {poke.Weight}");
                
            } 
            catch ( Exception e ) 
            { 
                Console.WriteLine(e.Message); 
            }
        }

        // ---------------------------------- REQUISIÇÃO API ---------------------------------------

        public string GetPokemon(string pokeName)
        {
            var options = new RestClientOptions("https://pokeapi.co")
            {
                ThrowOnAnyError = true,
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest($"https://pokeapi.co/api/v2/pokemon/{pokeName}", Method.Get);
            RestResponse response = client.Execute(request);
            if(response.StatusCode == System.Net.HttpStatusCode.NotFound )
            {
                throw new Exception("Pokemon não encontrado, tente outro pokemon.");
            }

            return response.Content;
        }

        // ----------------------------------------- MENU DE OPÇÕES -----------------------------------------
        public void StartMenu()
        {
            Console.WriteLine("                  ______ _____ _   __ ___________ _______   __\r\n                  | ___ \\  _  | | / /|  ___|  _  \\  ___\\ \\ / /\r\n                  | |_/ / | | | |/ / | |__ | | | | |__  \\ V / \r\n                  |  __/| | | |    \\ |  __|| | | |  __| /   \\ \r\n                  | |   \\ \\_/ / |\\  \\| |___| |/ /| |___/ /^\\ \\\r\n                  \\_|    \\___/\\_| \\_/\\____/|___/ \\____/\\/   \\/\r\n                                                              ");
            Console.WriteLine("\n");
        }

        public void MenuOptions() {
            Console.WriteLine("                          ___  ___ _____ _   _ _   _ \r\n                          |  \\/  ||  ___| \\ | | | | |\r\n                          | .  . || |__ |  \\| | | | |\r\n                          | |\\/| ||  __|| . ` | | | |\r\n                          | |  | || |___| |\\  | |_| |\r\n                          \\_|  |_/\\____/\\_| \\_/\\___/ ");
            Console.WriteLine("\n1 -> Search for the pokemon!");
            Console.WriteLine("\n2 -> Exit");
            Console.Write("\nSELECT ONE OPTION FROM ABOVE: ");
            int response = Convert.ToInt32(Console.ReadLine());
            MenuOptionValidation(response);
            bool switchValidation = true;
            while (switchValidation) {
             switch (response) {
                case 1: Console.Clear();
                        ShowPoke();
                        switchValidation = false;
                        break;
                case 2: switchValidation = false;
                        break;
            }
            }
        }

        //VALIDAÇÃO MENU DE OPÇÕES      
        public void MenuOptionValidation(int option)
        {
            if(option > 2 || option < 0)
            {
                throw new Exception("Digite um número válido!");
            }
        }

    }
}
