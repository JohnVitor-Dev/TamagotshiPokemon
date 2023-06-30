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
            OVO(PokeName);
            Console.WriteLine("\n1 - Voltar");
        }
        public static void MeusMascotes(string M1, string M2, string M3)
        {
            Console.WriteLine("\n----------------------- Mascotes -----------------------");
            if(M1 == null)
            {
                Console.WriteLine("Você não possui mascotes!");
            }
            else if (M2 == null)
            {
                Console.WriteLine($"1 - {M1}");
            }
            else if(M3 == null)
            {
                Console.WriteLine($"1 - {M1}");
                Console.WriteLine($"2 - {M2}");
            }
            else
            {
                Console.WriteLine($"1 - {M1}");
                Console.WriteLine($"2 - {M2}");
                Console.WriteLine($"3 - {M3}");
            }

            Console.WriteLine("\n4 - Voltar");
        }
        public static void API(string userName, float height, float weight, string PokeName)
        {
            Console.WriteLine($"\n------------------ {PokeName} ------------------");
            Console.WriteLine("Nome do Pokémon: " + userName);
            Console.WriteLine("Altura: " + height);
            Console.WriteLine("Peso: " + weight);
            Console.WriteLine("\nHabilidades:");
        }

        public static void OVO(string PokeName)
        {
            string frase = "MASCOTE ADOTADO COM SUCESSO, O OVO ESTÁ CHOCANDO:";
            string linha = "________________________________________________";

            // Frama 1
            Console.WriteLine(linha);
            Console.WriteLine(@"
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
                ████████        ");

            Console.WriteLine(linha);
            Console.WriteLine(frase);
            Thread.Sleep(3000);

            // Frame 2
            Console.Clear();
            Console.WriteLine(linha);
            Console.WriteLine(@"
                  ████          
              ████░░▒▒████      
            ██░░░░░░░░▒▒▒▒██    
            ██░░░░░░░░░---██    
          ██░░░░░░░░░░░/▒▒▒▒██  
          ██░/___░░░░░░░▒▒▒▒██  
        ██--/░░░░\░░░░░░▒▒▒▒▒▒██
        ██░░░░░░░░░░░░░░▒▒▒▒▒▒██
        ██▒▒░░░░░░░░░░▒▒▒\▒▒▒▒██
          ██░░░░░░░░▒▒▒▒▒---██  
          ██▒▒▒▒░░░░▒▒▒▒▒▒▒▒██  
            ████▒▒▒▒▒▒▒▒████    
                ████████        ");

            Console.WriteLine(linha);
            Console.WriteLine(frase);
            Thread.Sleep(3000);

            // Frame 3
            Console.Clear();
            Console.WriteLine(linha);
            Console.WriteLine(@"
                  ████          
              ████░░▒▒████      
            ██░░░░░░░░▒▒▒▒██    
            ██░░░__░░░░---██    
          ██░░░░░░░\░_░/▒▒▒▒██  
          ██░)___░░░/░░░▒▒▒▒██  
        ██--(░░░░\__░░░░▒(___▒██
        ██░░░░░░░/░░)____▒▒▒▒▒██
        ██▒▒░░__/░░░░)▒▒▒)▒▒▒▒██
          ██░(░░░░__(▒▒▒▒---██  
          ██▒▒▒▒░░░░▒▒▒▒▒▒▒▒██  
            ████▒▒▒▒▒▒▒▒████    
                ████████        ");

            Console.WriteLine(linha);
            Console.WriteLine(frase);
            Thread.Sleep(3000);

            // Frame 4
            Console.Clear();
            Console.WriteLine(linha);
            Pokemon(PokeName);
            Console.WriteLine(linha);
            


        }
        public static void Pokemon(string PokeName)
        {
            if(PokeName == "Bulbasaur")
            {
                Console.WriteLine(@"              
                        ##  ##          
                      ##::##::##        
                    ####::----##        
                ####::@@@@::@@--####    
              ##::::@@--@@::@@--::@@##  
      ##    ##++--@@--::@@::::@@::--@@##
    ##--######++@@++::@@--::::::@@--++##
    ##------++####++++@@--::::::@@++++##
    ##----++++++++##++@@++++++++@@++++##
  ##------++++++--++######++++++@@++##  
  ##++----------------++##++++@@####    
####++------++--------##++######++##    
##--------++--######--++++++++++++++##  
  ##--------####    ++++++##++++++++##  
  ##++------####  ++++++++++##++++++##  
    ####++++++++++++##++++++##++  ##    
        ############++++++++######      
                  ##  ++  ####          
                    ########            ");
            }
            else if(PokeName == "Charmander")
            {
                Console.WriteLine(@"                                        
        ##                              
      ##++##                            
    ##++++##            ########        
    ##++++##          ##--------##      
  ##++++++++##      MM------------##    
  ##++  ++++##      MM------------##    
  ##++    ++##      MM--------------##  
    ####  ##        MM----##  --------##
      ##--##      ##------####--------##
      ####--##  ##--------####--------##
        ##----####------------------##  
        ##----------------------####    
        ####----------##----####        
          ####------####    ##          
            ####------    ##  ##        
              ##------  ######          
              ####--####                
              ##  --mm                  
              ######++                  ");
            }
            else if(PokeName == "Squirtle")
            {
                Console.WriteLine(@"                            
          ########                      ##########          
        ##++++++++##                ####++++++++++####      
      ##MM++++++++++####      ######++++++++++++++++++##    
      ##MM++++++++++####      ######++++++++++++++++++##    
      ##MM####MM++++####  ####@@@@##++++++++++++++++++##    
      ##MMMMMM##MM++++++##@@@@@@@@MM++++++++++++++++++@@##  
        ##MMMM##MM++####@@@@@@    MM++++####  ++++++++++##  
          ########MM####@@@@@@    MMMM++@@@@##++++++++MM##  
          ########MM####@@@@@@    MMMM++@@@@##++++++++MM##  
                ####@@@@@@@@  ####MMMMMM@@@@##++MMMMMM##    
                  ##@@@@@@  ++++++####MMMMMMMMMM######      
                  ##@@@@@@  MM++++++++##########++####      
                  ##@@@@@@  ##MMMMMM++##      ####          
                  ##@@@@@@  ##MMMMMM++##      ####          
                  ##@@@@@@    ########      ##              
                    ####  ##++          ####MM##            
                    ####  ##++      ##########              
                        ####++########                      
                        ####++########                      
                        ##MMMMMMMM##                        
                          ########                          
                                                            ");
            }
        }

    }
}
