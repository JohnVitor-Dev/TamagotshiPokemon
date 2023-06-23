using System;
using System.Threading;
using RestSharp;
using RestSharp.Authenticators;

public static class APIpokemon
{
    public static void Main()
    {
        int ID_Pokemon = EscolherPokemon();

        var options = new RestClientOptions($"https://pokeapi.co/api/v2/pokemon/{ID_Pokemon}/");
        var client = new RestClient(options);

        var request = new RestRequest("", Method.Get);

        var response = client.Execute(request);

        Console.Clear();
        Console.WriteLine(response.Content);
        
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