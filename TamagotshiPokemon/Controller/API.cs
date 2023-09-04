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
        public PokemonModel.Pokemon ConexaoAPI(int ID_Pokemon)
        {
            var options = new RestClientOptions($"https://pokeapi.co/api/v2/pokemon/{ID_Pokemon}/");
            var client = new RestClient(options);
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);
            PokemonModel.Pokemon pokemon = null;

            if (response.IsSuccessful) 
            { 
                pokemon = JsonConvert.DeserializeObject<PokemonModel.Pokemon>(response.Content); 
            }
            else
            {
                Console.WriteLine("Não foi possível conectar-se à API. Por favor, verifique a sua conexão com a internet!");
                Thread.Sleep(5000);
                return null;
            }
            return pokemon;
        }
    }
}
