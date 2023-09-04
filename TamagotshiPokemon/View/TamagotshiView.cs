using API.Controller;
using Pokemon.Model;
using Tamagotshi.Controller;
using User.Model;

namespace Tamagotshi.View
{
    public class TView
    {

        private TControl tControl;
        public TView(TControl _tControl)
        {
            tControl = _tControl;
        }

        public void Titulo()
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

        public void GetUser()
        {
            Console.WriteLine("\n\n1 - Novo Usuário");
            Console.WriteLine("2 - Continuar");
        }

        public void ExibirUsers(List<UserModel> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id} | Nome: {user.Name}");
            }
        }

        public void MenuInicial(string userName)
        {
            Console.WriteLine("\n------------------------- MENU -------------------------");
            Console.WriteLine($"{userName} Você deseja: \n ");
            Console.WriteLine("1 - Adotar um mascote virtual");
            Console.WriteLine("2 - Ver seus mascotes");
            Console.WriteLine("3 - Sair");
        }

        public void Adotar(string userName)
        {
            Console.WriteLine("\n------------------ ADOTAR UM MASCOTE ------------------");
            Console.WriteLine($"{userName} Escolha uma espécie: \n ");
            Console.WriteLine("1 - Bulbasaur");
            Console.WriteLine("2 - Charmander");
            Console.WriteLine("3 - Squirtle");
            Console.WriteLine("4 - Voltar");
        }

        public void AdotarInfo(string userName, string PokeName)
        {
            Console.WriteLine("\n-------------------------------------------------------");
            Console.WriteLine($"{userName} Você deseja: \n ");
            Console.WriteLine($"1 - Saber mais sobre {PokeName}");
            Console.WriteLine($"2 - Adotar {PokeName}");
            Console.WriteLine("3 - Voltar");
        }

        public void ConcluirAdocao(string userName, string PokeName)
        {
            OVO(PokeName);
            Console.WriteLine("\n1 - Voltar");
        }

        public void MeusMascotes(List<string> mascotes)
        {
            Console.WriteLine("\n----------------------- Mascotes -----------------------");
            if (mascotes.Count == 0)
            {
                Console.WriteLine("Você não possui mascotes!");
            }
            else
            {
                foreach(string mascote in mascotes)
                {  
                    Console.WriteLine(mascote);
                }
            }

            Console.WriteLine("\n4 - Voltar");
        }

        public void SobreMascote(string userName, string PokeName, APIControl apiControl)
        {
            if (PokeName == "Bulbasaur")
            {
                int ID = 1;
                PokemonModel.Pokemon pokemon = apiControl.ConexaoAPI(ID);

                Console.Clear();
                Console.WriteLine($"\n------------------ {PokeName} ------------------");
                Console.WriteLine("Nome do Pokémon: " + pokemon.name);
                Console.WriteLine("\nHabilidades:");

                foreach (PokemonModel.AbilityInfo abilityInfo in pokemon.Abilities) { Console.WriteLine(abilityInfo.Ability.Name); }

                Console.WriteLine("\n1 - Voltar");

            }
            else if(PokeName == "Charmander")
            {
                int ID = 4;
                PokemonModel.Pokemon pokemon = apiControl.ConexaoAPI(ID);

                Console.Clear();
                Console.WriteLine($"\n------------------ {PokeName} ------------------");
                Console.WriteLine("Nome do Pokémon: " + pokemon.name);
                Console.WriteLine("\nHabilidades:");

                foreach (PokemonModel.AbilityInfo abilityInfo in pokemon.Abilities) { Console.WriteLine(abilityInfo.Ability.Name); }

                Console.WriteLine("\n1 - Voltar");
            } 
            else if(PokeName == "Squirtle")
            {
                int ID = 7;
                PokemonModel.Pokemon pokemon = apiControl.ConexaoAPI(ID);

                Console.Clear();
                Console.WriteLine($"\n------------------ {PokeName} ------------------");
                Console.WriteLine("Nome do Pokémon: " + pokemon.name);
                Console.WriteLine("\nHabilidades:");

                foreach (PokemonModel.AbilityInfo abilityInfo in pokemon.Abilities) { Console.WriteLine(abilityInfo.Ability.Name); }

                Console.WriteLine("\n1 - Voltar");

            }
        }

        public void API(PokemonModel.Pokemon pokemon, string PokeName)
        {
            Console.WriteLine($"\n------------------ {PokeName} ------------------");
            Console.WriteLine("Nome do Pokémon: " + pokemon.name);
            Console.WriteLine("Altura: " + pokemon.height);
            Console.WriteLine("Peso: " + pokemon.weight);
            Console.WriteLine("\nHabilidades:");

            foreach (PokemonModel.AbilityInfo abilityInfo in pokemon.Abilities)
            {
                Console.WriteLine(abilityInfo.Ability.Name);
            }
        }

        public void OVO(string PokeName)
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
            Thread.Sleep(2000);

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
            Thread.Sleep(2000);

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
            Thread.Sleep(2000);

            // Frame 4
            Console.Clear();
            Console.WriteLine(linha);
            Pokemon(PokeName);
            Console.WriteLine(linha);
        }

        public void Pokemon(string PokeName)
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
