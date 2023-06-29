using System;
using Newtonsoft.Json;
using Pokemon.Model;
using RestSharp;
using Tamagotshi.View;

namespace API.Controller
{
    public static class APIControl
    {
        public static void ConexaoAPI(string nome, string PokeName, int ID_Pokemon)
        {
            //Console.Clear();
            //Titulo();
            //Console.WriteLine($"\n------------------ {PokeName} ------------------");

            var options = new RestClientOptions($"https://pokeapi.co/api/v2/pokemon/{ID_Pokemon}/");
            var client = new RestClient(options);

            var request = new RestRequest("", Method.Get);

            var response = client.Execute(request);

            PokemonModel.Pokemon pokemon = JsonConvert.DeserializeObject<PokemonModel.Pokemon>(response.Content);

            TView.API(pokemon.name, pokemon.height, pokemon.weight);


            foreach (PokemonModel.AbilityInfo abilityInfo in pokemon.Abilities)
            {
                Console.WriteLine(abilityInfo.Ability.Name);
            }

            Console.WriteLine("\n1 - Adotar");
            Console.WriteLine("2 - Voltar");
            int Escolha = int.Parse(Console.ReadLine());

            if (Escolha == 1)
            {
                TView.ConcluirAdocao(nome, PokeName);
            }
            else if (Escolha == 2)
            {
                TView.Adotar(nome);
            }
            else
            {
                ConexaoAPI(nome, PokeName, ID_Pokemon);
            }
        }
    }
}
