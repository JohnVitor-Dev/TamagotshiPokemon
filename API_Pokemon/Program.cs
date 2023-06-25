using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;

public static class APIpokemon
{
    public class Ability
    {
        public string Name { get; set; }
    }

    public class AbilityInfo
    {
        public Ability Ability { get; set; }
    }

    public class Mascote
    {
        public string name { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public List<AbilityInfo> Abilities { get; set; }

    }

    public static void Main()
    {
        int ID_Pokemon = EscolherPokemon();

        var options = new RestClientOptions($"https://pokeapi.co/api/v2/pokemon/{ID_Pokemon}/");
        var client = new RestClient(options);

        var request = new RestRequest("", Method.Get);

        var response = client.Execute(request);

        Console.Clear();

        Mascote mascote = JsonConvert.DeserializeObject<Mascote>(response.Content);

        Console.WriteLine("Nome do Pokémon: " + mascote.name);
        Console.WriteLine("Altura: " + mascote.height);
        Console.WriteLine("Peso: " + mascote.weight);
        Console.WriteLine("\nHabilidades:");

        foreach (AbilityInfo abilityInfo in mascote.Abilities)
        {
            Console.WriteLine(abilityInfo.Ability.Name);
        }

    }

    public static int EscolherPokemon()
    {
        int ID_Pokemon = 0;

        Console.WriteLine("1 - Bulbasaur \n2 - Charmander \n3 - Squirtle \n\nEscolha um Pokémon: ");
        string Pokemon = Console.ReadLine();

        if (Pokemon == "1")
        {
            ID_Pokemon = 1;
        }
        else if (Pokemon == "2")
        {
            ID_Pokemon = 4;
        }
        else if (Pokemon == "3")
        {
            ID_Pokemon = 7;
        }
        else
        {
            Console.WriteLine("Número Inválido!");
            Environment.Exit(0);
        }

        return ID_Pokemon;
    }

}