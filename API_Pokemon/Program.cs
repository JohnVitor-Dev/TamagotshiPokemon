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
        Titulo();

        Console.WriteLine("Qual o seu nome?");
        string nameUsuario = Console.ReadLine();

        MenuInicial(nameUsuario);

    }
    public static void Titulo()
    {
        Console.WriteLine(" _                                    _       _     _ ");
        Console.WriteLine("| |                                  | |     | |   (_)");
        Console.WriteLine("| |_ __ _ _ __ ___   __ _  __ _  ___ | |_ ___| |__  _ ");
        Console.WriteLine("| __/ _` | '_ ` _ \\ / _` |/ _` |/ _ \\| __/ __| '_ \\| |");
        Console.WriteLine("| || (_| | | | | | | (_| | (_| | (_) | || (__| | | | |");
        Console.WriteLine(" \\__\\__,_|_| |_| |_|\\__,_|\\__, |\\___/ \\__\\___|_| |_|_|");
        Console.WriteLine("                           __/ |                      ");
        Console.WriteLine("                          |___/                       ");


    }
    public static void MenuSystem(string nome, int Escolha)
    {
        if(Escolha == 1)
        {
            Adotar(nome);
        } 
        else if(Escolha == 2)
        {
            MeusMascotes();
        } 
        else if(Escolha == 3)
        {
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Opção Inválida!");
        }
    }
    public static void MenuInicial(string nome)
    {
        Console.Clear();
        Titulo();
        Console.WriteLine("\n------------------------- MENU -------------------------");
        Console.WriteLine($"{nome} Você deseja: \n ");
        Console.WriteLine("1 - Adotar um mascote virtual");
        Console.WriteLine("2 - Ver seus mascotes");
        Console.WriteLine("3 - Sair");
        
        int Escolha = int.Parse(Console.ReadLine());
        MenuSystem(nome, Escolha);
    }
    public static void Adotar(string nome)
    {
        Console.Clear();
        Titulo();

        Console.WriteLine("\n------------------ ADOTAR UM MASCOTE ------------------");
        Console.WriteLine($"{nome} Escolha uma espécie: \n ");
        Console.WriteLine("1 - Bulbasaur");
        Console.WriteLine("2 - Charmander");
        Console.WriteLine("3 - Squirtle");
        Console.WriteLine("4 - Voltar");

        int Escolha = int.Parse(Console.ReadLine());
        string PokeName = "";
        int ID_Pokemon = 0;

        if(Escolha == 1)
        {
            PokeName = "Bulbasaur";
            ID_Pokemon = 1;
        }
        else if(Escolha == 2)
        {
            PokeName = "Charmander";
            ID_Pokemon = 4;
        } 
        else if(Escolha == 3)
        {
            PokeName = "Squirtle";
            ID_Pokemon = 7;
        }
        else if(Escolha == 4)
        {
            MenuInicial(nome);
        }
        else
        {
            Adotar(nome);
        }

        AdotarInfo(nome, PokeName, ID_Pokemon);

        
    }
    public static void AdotarInfo(string nome, string PokeName, int ID_Pokemon)
    {
        Console.Clear();
        Titulo();

        Console.WriteLine("\n-------------------------------------------------------");
        Console.WriteLine($"{nome} Você deseja: \n ");
        Console.WriteLine($"1 - Saber mais sobre {PokeName}");
        Console.WriteLine($"2 - Adotar {PokeName}");
        Console.WriteLine("3 - Voltar");

        int Escolha = int.Parse(Console.ReadLine());

        if (Escolha == 1)
        {
            ConexaoAPI(nome, PokeName, ID_Pokemon);
        }
        else if (Escolha == 2)
        {
            ConcluirAdocao(nome, PokeName);
        }
        else if (Escolha == 3)
        {
            Adotar(nome);
        }
        else
        {
            AdotarInfo(nome, PokeName, ID_Pokemon);
        }


    }
    public static void ConcluirAdocao(string nome, string PokeName)
    {
        Console.Clear();
        Console.WriteLine("MASCOTE ADOTADO COM SUCESSO, O OVO ESTÁ CHOCANDO: \n");
        Console.WriteLine(@$"
                  ████          
              ████░░▒▒████      
            ██░░░░░░░░▒▒▒▒██    
            ██░░░░░░░░░░▒▒██    
          ██░░░░░░░░░░░░▒▒▒▒██  
          ██░░░░░░░░░░░░▒▒▒▒██  
        ██░░░░░░░░░░░░░░▒▒▒▒▒▒██
        ██░░░░░░░░░░░░░░▒▒▒▒▒▒██
        ██▒▒░░░░░░░░░░▒▒▒▒▒▒▒▒██
          ██░░░░░░░░▒▒▒▒▒▒▒▒██  
          ██▒▒▒▒░░░░▒▒▒▒▒▒▒▒██  
            ████▒▒▒▒▒▒▒▒████    
                ████████        

               {PokeName}
");
       
    }
    public static void MeusMascotes()
    {
        Console.WriteLine("Mascotes");
    }
    public static void ConexaoAPI(string nome, string PokeName, int ID_Pokemon)
    {
        Console.Clear();
        Titulo();
        Console.WriteLine($"\n------------------ {PokeName} ------------------");

        var options = new RestClientOptions($"https://pokeapi.co/api/v2/pokemon/{ID_Pokemon}/");
        var client = new RestClient(options);

        var request = new RestRequest("", Method.Get);

        var response = client.Execute(request);

        

        Mascote mascote = JsonConvert.DeserializeObject<Mascote>(response.Content);

        Console.WriteLine("Nome do Pokémon: " + mascote.name);
        Console.WriteLine("Altura: " + mascote.height);
        Console.WriteLine("Peso: " + mascote.weight);
        Console.WriteLine("\nHabilidades:");


        foreach (AbilityInfo abilityInfo in mascote.Abilities)
        {
            Console.WriteLine(abilityInfo.Ability.Name);
        }

        Console.WriteLine("\n1 - Adotar");
        Console.WriteLine("2 - Voltar");
        int Escolha = int.Parse(Console.ReadLine());

        if(Escolha == 1)
        {
            ConcluirAdocao(nome, PokeName);
        }
        else if(Escolha == 2)
        {
            Adotar(nome);
        }
        else
        {
            ConexaoAPI(nome, PokeName, ID_Pokemon);
        }
    }

    

}