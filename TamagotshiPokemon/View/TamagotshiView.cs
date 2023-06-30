using System;
using Tamagotshi.Controller;

namespace Tamagotshi.View
{
    public static class TView
    {
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
        public static void GetName()
        {
            Console.WriteLine("\n\nQual o seu nome?");
        }
        public static void MenuInicial(string userName)
        {
            Console.WriteLine("\n------------------------- MENU -------------------------");
            Console.WriteLine($"{userName} Você deseja: \n ");
            Console.WriteLine("1 - Adotar um mascote virtual");
            Console.WriteLine("2 - Ver seus mascotes");
            Console.WriteLine("3 - Sair");
        }

        public static void Adotar(string userName)
        {
            Console.WriteLine("\n------------------ ADOTAR UM MASCOTE ------------------");
            Console.WriteLine($"{userName} Escolha uma espécie: \n ");
            Console.WriteLine("1 - Bulbasaur");
            Console.WriteLine("2 - Charmander");
            Console.WriteLine("3 - Squirtle");
            Console.WriteLine("4 - Voltar");
        }
        public static void AdotarInfo(string userName, string PokeName)
        {
            Console.WriteLine("\n-------------------------------------------------------");
            Console.WriteLine($"{userName} Você deseja: \n ");
            Console.WriteLine($"1 - Saber mais sobre {PokeName}");
            Console.WriteLine($"2 - Adotar {PokeName}");
            Console.WriteLine("3 - Voltar");
        }
        public static void ConcluirAdocao(string userName, string PokeName)
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
        public static void API(string userName, float height, float weight, string PokeName)
        {
            Console.WriteLine($"\n------------------ {PokeName} ------------------");
            Console.WriteLine("Nome do Pokémon: " + userName);
            Console.WriteLine("Altura: " + height);
            Console.WriteLine("Peso: " + weight);
            Console.WriteLine("\nHabilidades:");
        }

    }
}
