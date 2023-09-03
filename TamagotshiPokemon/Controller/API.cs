using System;
using Newtonsoft.Json;
using Pokemon.Model;
using RestSharp;
using Tamagotshi.View;
using Tamagotshi.Controller;
using Start.Controller;

namespace API.Controller
{
    public class APIControl
    {
       
        // Criação das dependências
        private TView tView;
        private TControl tControl;

        public APIControl(TView _tView, TControl _tControl)
        {
            tView = _tView;
            tControl = _tControl;
        }
       
        // Conexão Com a API
        public void ConexaoAPI(string userName, string PokeName, int ID_Pokemon)
        {
            
            var options = new RestClientOptions($"https://pokeapi.co/api/v2/pokemon/{ID_Pokemon}/");
            var client = new RestClient(options);

            var request = new RestRequest("", Method.Get);

            var response = client.Execute(request);

            PokemonModel.Pokemon pokemon = JsonConvert.DeserializeObject<PokemonModel.Pokemon>(response.Content);

            Console.Clear();
            tView.Titulo();
            tView.API(pokemon.name, pokemon.height, pokemon.weight, PokeName);

            foreach (PokemonModel.AbilityInfo abilityInfo in pokemon.Abilities)
            {
                Console.WriteLine(abilityInfo.Ability.Name);
            }

            Console.WriteLine("\n1 - Adotar");
            Console.WriteLine("2 - Voltar");

            string escolha = Console.ReadLine();
            int number;
            bool escolheisNumber = int.TryParse(escolha, out number);

            if(escolheisNumber == false)
            {
                Console.WriteLine("Número inválido!");
                Thread.Sleep(2000);
                ConexaoAPI(userName, PokeName, ID_Pokemon);
            }

            if (number == 1)
            {
                if (tControl.PossuiPokemon(PokeName) == false)
                {
                    tControl.ConcluirAdocao(userName, PokeName);
                }
                else
                {
                    Console.WriteLine("Pokemon já foi adotado!");
                    Thread.Sleep(2000);
                    tControl.Adotar(userName);
                }
            }
            else if (number == 2)
            {
                tControl.Adotar(userName);
            }
            else
            {
                Console.WriteLine("opção inválida!");
                Thread.Sleep(2000);
                ConexaoAPI(userName, PokeName, ID_Pokemon);
            }
        }
    }
}
