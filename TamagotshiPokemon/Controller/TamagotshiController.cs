using API.Controller;
using Pokemon.Model;
using Tamagotshi.Data;
using Tamagotshi.View;
using User.Model;
using static Pokemon.Model.PokemonModel;

namespace Tamagotshi.Controller
{
    public class TControl
    {
        public UserModel userGlobal;
        private APIControl apiControl;
        private TView tView;
        private readonly TContext _context;
        public TControl(TView _tView, TContext context)
        {
            tView = _tView;
            _context = context;
            apiControl = new APIControl(tView, this);
        }

        public void User()
        {
            Console.Clear();
            tView.Titulo();
            tView.GetUser();
            string escolhaUser = Console.ReadLine();
            int number;
            bool escolhaUserisNumber = int.TryParse(escolhaUser, out number);

            if (escolhaUserisNumber == false)
            {
                Console.WriteLine("Numero inválido!");
                Thread.Sleep(2000);
                User();
            }

            if(number == 1)
            {
                Console.Clear();
                tView.Titulo();
                Console.WriteLine("Insira seu nome: ");
       
                UserModel user = new UserModel();
                user.Name = Console.ReadLine();

                // Obs: uso do async não necessário
                _context.UserInventory.Add(user);
                _context.SaveChanges();

                // Definir o user atual que está sendo usado.
                Login(user);

            } 
            else if(number == 2)
            {
                Console.Clear();
                tView.Titulo();
                Console.WriteLine("Usuários: \n");

                List<UserModel> users = _context.UserInventory.ToList();
                tView.ExibirUsers(users);

                Console.WriteLine("\nEscolha o ID do seu save: ");
                string save = Console.ReadLine();
                int saveID;
                bool saveisNumber = int.TryParse(save, out saveID);

                if (saveisNumber == false)
                {
                    Console.WriteLine("Numero inválido!");
                    Thread.Sleep(2000);
                    User();
                }

                UserModel user = new UserModel();
                user = _context.UserInventory.Find(saveID);

                if(user == null)
                {
                    Console.WriteLine("Save não encontrado!");
                    Thread.Sleep(2000);
                    User();
                }

                Login(user);

            } 
            else
            {
                Console.WriteLine("Opção Inválida!");
                Thread.Sleep(2000);
                User();
            }
        }

        public void Login(UserModel user)
        {
            userGlobal = user;
            MenuInicial();
        }

        public void MenuInicial()
        {
            Console.Clear();
            tView.Titulo();
            tView.MenuInicial(userGlobal.Name);

            string escolha = Console.ReadLine();
            int number;
            bool escolhaisNumber = int.TryParse(escolha, out number);

            if(escolhaisNumber == false)
            { 
                Console.WriteLine("Número inválido!");
                Thread.Sleep(2000);
                MenuInicial();
            }

            switch (number)
            {
                case 1:
                    Adotar(userGlobal.Name);
                    break;
                case 2:
                    MyMascotes();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção Inválida!!");
                    Thread.Sleep(2000);
                    MenuInicial();
                    break;
            }
        }

        public void Adotar(string userName)
        {
            Console.Clear();
            tView.Titulo();
            tView.Adotar(userName);

            string escolha = Console.ReadLine();
            int number;
            bool escolhaisNumber = int.TryParse(escolha, out number);

            if (escolhaisNumber == false)
            {
                Console.WriteLine("Número inválido!");
                Thread.Sleep(2000);
                Adotar(userName);
            }

            string PokeName;
            int ID_Pokemon;

            switch (number)
            {
                case 1:
                    PokeName = "Bulbasaur";
                    ID_Pokemon = 1;
                    AdotarInfo(userName, PokeName, ID_Pokemon);
                    break;
                case 2:
                    PokeName = "Charmander";
                    ID_Pokemon = 4;
                    AdotarInfo(userName, PokeName, ID_Pokemon);
                    break;
                case 3:
                    PokeName = "Squirtle";
                    ID_Pokemon = 7;
                    AdotarInfo(userName, PokeName, ID_Pokemon);
                    break;
                case 4:
                    MenuInicial();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Thread.Sleep(2000);
                    Adotar(userName);
                    break;
            }
        }

        public void AdotarInfo(string userName, string PokeName, int ID_Pokemon)
        {
            Console.Clear();
            tView.Titulo();
            tView.AdotarInfo(userName, PokeName);

            string escolha = Console.ReadLine();
            int number;
            bool escolhaisNumber = int.TryParse(escolha, out number);

            if (escolhaisNumber == false)
            {
                Console.WriteLine("Número inválido!");
                Thread.Sleep(2000);
                AdotarInfo(userName, PokeName, ID_Pokemon);
            }

            switch (number)
            {
                case 1:
                    PokemonModel.Pokemon pokemon = apiControl.ConexaoAPI(ID_Pokemon);

                    if(pokemon == null) { MenuInicial(); }

                    Console.Clear();
                    tView.Titulo();
                    tView.API(pokemon, PokeName);

                    Console.WriteLine("\n1 - Adotar");
                    Console.WriteLine("2 - Voltar");

                    string escolha1 = Console.ReadLine();
                    int number1;
                    bool escolhaisNumber1 = int.TryParse(escolha1, out number1);

                    if (escolhaisNumber1 == false)
                    {
                        Console.WriteLine("Número inválido!");
                        Thread.Sleep(2000);
                        AdotarInfo(userName, PokeName, ID_Pokemon);
                    }

                    if (number1 == 1)
                    {
                        if (PossuiPokemon(PokeName) == false)
                        {
                            ConcluirAdocao(userName, PokeName);
                        }
                        else
                        {
                            Console.WriteLine("Pokemon já foi adotado!");
                            Thread.Sleep(2000);
                            Adotar(userName);
                        }
                    }
                    else if (number1 == 2)
                    {
                        Adotar(userName);
                    }
                    else
                    {
                        Console.WriteLine("opção inválida!");
                        Thread.Sleep(2000);
                        AdotarInfo(userName, PokeName, ID_Pokemon);
                    }
                    break;
                case 2:
                    if (PossuiPokemon(PokeName) == false)
                    {
                        ConcluirAdocao(userName, PokeName);
                    }
                    else
                    {
                        Console.WriteLine("Pokemon já foi adotado!");
                        Thread.Sleep(2000);
                        AdotarInfo(userName, PokeName, ID_Pokemon);
                    }
                    break;
                case 3:
                    Adotar(userName);
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Thread.Sleep(1000);
                    AdotarInfo(userName, PokeName, ID_Pokemon);
                    break;
            }
        }

        public bool PossuiPokemon(string PokeName)
        {
            bool Resposta = true;

            if (userGlobal.HasPokemon1 == 0 && PokeName == "Bulbasaur")
            {
                Resposta = false;
            }
            else if (userGlobal.HasPokemon2 == 0 && PokeName == "Charmander")
            {
                Resposta = false;
            }
            else if (userGlobal.HasPokemon3 == 0 && PokeName == "Squirtle")
            {
                Resposta = false;
            }

            return Resposta;
        }
       
        public void ConcluirAdocao(string userName, string PokeName)
        {
            Console.Clear();

            tView.ConcluirAdocao(userName, PokeName);

            if (PokeName == "Bulbasaur")
            {
                userGlobal.HasPokemon1 = 1;
                _context.UserInventory.Update(userGlobal);
                _context.SaveChanges();
            }
            else if (PokeName == "Charmander")
            {
                userGlobal.HasPokemon2 = 1;
                _context.UserInventory.Update(userGlobal);
                _context.SaveChanges();
            }
            else if (PokeName == "Squirtle")
            {
                userGlobal.HasPokemon3 = 1;
                _context.UserInventory.Update(userGlobal);
                _context.SaveChanges();
            }

            while (true)
            {
                string escolha = Console.ReadLine();
                int number;
                bool escolhaisNumber = int.TryParse(escolha, out number);

                if(escolhaisNumber == false)
                {
                    Console.WriteLine("Número inválido!");
                }
                else
                {
                    switch (number)
                    {
                        case 1:
                            MenuInicial();
                            break;
                        default:
                            Console.WriteLine("Opção Inválida!!");
                            break;
                    }
                }
            }
        }
        public void MyMascotes()
        {
            int[] mascotes = {userGlobal.HasPokemon1, userGlobal.HasPokemon2, userGlobal.HasPokemon3};
            int contador = 0;

            string optionOne = null;
            string optionTwo = null;
            string optionThree = null;

            List<string> nomeMascotes = new List<string>();

            for(int i = 0; i < mascotes.Length; i++) 
            {
                if (mascotes[i] == 1)
                {
                    string pokemon = null;

                    if(i == 0) { pokemon = "Bulbasaur"; }
                    if (i == 1) { pokemon = "Charmander"; }
                    if (i == 2) { pokemon = "Squirtle"; }

                    contador++;
                    nomeMascotes.Add($"{contador} - {pokemon}");

                    if(contador == 1) { optionOne = pokemon; }
                    if(contador == 2) { optionTwo = pokemon; }
                    if(contador == 3) { optionThree = pokemon; }
                }
            }

            Console.Clear();
            tView.Titulo();
            tView.MeusMascotes(nomeMascotes);

            string escolha = Console.ReadLine();
            int number;
            bool escolhaisNumber = int.TryParse(escolha, out number);

            if(escolhaisNumber == false) { Console.WriteLine("Número Inválido!"); Thread.Sleep(2000); MenuInicial(); }

            if (number == 1)
            {
                if (optionOne == null || optionOne == "")
                {
                    Console.WriteLine("Opção inválida!");
                    Thread.Sleep(2000);
                    MenuInicial();
                }
                else
                {
                    tView.SobreMascote(userGlobal.Name, optionOne, apiControl);

                    string escolhaSP = Console.ReadLine();
                    int numberSP;
                    bool escolhaisNumberSP = int.TryParse(escolha, out number);

                    if (escolhaisNumberSP == false) { Console.WriteLine("Número Inválido!"); Thread.Sleep(2000); MenuInicial(); }
                    if (number == 1) { MenuInicial(); }
                    else { MenuInicial(); }

                }
            }
            else if (number == 2)
            {
                if (optionTwo == null || optionTwo == "")
                {
                    Console.WriteLine("Opção inválida!");
                    Thread.Sleep(2000);
                    MenuInicial();
                }
                else
                {
                    tView.SobreMascote(userGlobal.Name, optionTwo, apiControl);
                    string escolhaSP = Console.ReadLine();
                    int numberSP;
                    bool escolhaisNumberSP = int.TryParse(escolha, out number);

                    if (escolhaisNumberSP == false) { Console.WriteLine("Número Inválido!"); Thread.Sleep(2000); MenuInicial(); }
                    if (number == 1) { MenuInicial(); }
                    else { MenuInicial(); }
                }
            }
            else if (number == 3)
            {
                if (optionThree == null || optionThree == "")
                {
                    Console.WriteLine("Opção inválida!");
                    Thread.Sleep(2000);
                    MenuInicial();
                }
                else
                {
                    tView.SobreMascote(userGlobal.Name, optionThree, apiControl);
                    string escolhaSP = Console.ReadLine();
                    int numberSP;
                    bool escolhaisNumberSP = int.TryParse(escolha, out number);

                    if (escolhaisNumberSP == false) { Console.WriteLine("Número Inválido!"); Thread.Sleep(2000); MenuInicial(); }
                    if (number == 1) { MenuInicial(); }
                    else { MenuInicial(); }
                }
            }
            else if (number == 4)
            {
                MenuInicial();
            }
            else
            {
                Console.WriteLine("Opção inválida!");
                Thread.Sleep(2000);
                MenuInicial();
            }

            
        }

    }
}
