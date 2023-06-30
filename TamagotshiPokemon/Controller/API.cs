using System;
using Newtonsoft.Json;
using Pokemon.Model;
using RestSharp;
using Tamagotshi.View;
using Tamagotshi.Controller;

namespace API.Controller
{
    public static class APIControl
    {
        public static void ConexaoAPI(string userName, string PokeName, int ID_Pokemon)
        {
            
            var options = new RestClientOptions($"https://pokeapi.co/api/v2/pokemon/{ID_Pokemon}/");
            var client = new RestClient(options);

            var request = new RestRequest("", Method.Get);

            var response = client.Execute(request);

            PokemonModel.Pokemon pokemon = JsonConvert.DeserializeObject<PokemonModel.Pokemon>(response.Content);

            Console.Clear();
            TView.Titulo();
            TView.API(pokemon.name, pokemon.height, pokemon.weight, PokeName);


            foreach (PokemonModel.AbilityInfo abilityInfo in pokemon.Abilities)
            {
                Console.WriteLine(abilityInfo.Ability.Name);
            }

            Console.WriteLine("\n1 - Adotar");
            Console.WriteLine("2 - Voltar");

            int Escolha = int.Parse(Console.ReadLine());

            if (Escolha == 1)
            {
                if (TControl.PossuiPokemon(PokeName) == true)
                {
                    TControl.ConcluirAdocao(userName, PokeName);
                } 
                else
                {
                    Console.WriteLine("Pokemon já foi adotado!");
                    Thread.Sleep(3000);
                    TControl.Adotar(userName);
                }
            }
            else if (Escolha == 2)
            {
                TControl.Adotar(userName);
            }
            else
            {
                ConexaoAPI(userName, PokeName, ID_Pokemon);
            }
        }
    }
}
