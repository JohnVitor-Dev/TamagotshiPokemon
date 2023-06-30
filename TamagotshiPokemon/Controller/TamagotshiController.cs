using System;
using Newtonsoft.Json;
using Pokemon.Model;
using RestSharp;
using Tamagotshi.View;
using Pokemon.Model;
using API.Controller;
using User.Model;
using System.Security.Cryptography.X509Certificates;

namespace Tamagotshi.Controller
{
    public static class TControl
    {
        public static void MenuSystem(string userName, int Escolha)

        {
            switch(Escolha)
            {
                case 1:
                    Adotar(userName);
                    break;
                case 2:
                    MyMascotes(userName);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção Inválida!!");
                    break;
                }
        }
        public static bool PossuiPokemon(string PokeName)
        {
            bool Resposta = false;

            if (UserModel.temBulbasaur == false && PokeName == "Bulbasaur")
            {
                Resposta = true;
            }
            else if (UserModel.temCharmander == false && PokeName == "Charmander")
            {
                Resposta = true;
            }
            else if (UserModel.temSquirtle == false && PokeName == "Squirtle")
            {
                Resposta = true;
            }

            return Resposta;
        }
        public static void AtribuirMascote(string PokeName)
        {
            if (UserModel.Mascotes[0] == null)
            {
                UserModel.Mascotes[0] = PokeName;
            }
            else if(UserModel.Mascotes[1] == null)
            {
                UserModel.Mascotes[1] = PokeName;
            }
            else if(UserModel.Mascotes[2] == null)
            {
                UserModel.Mascotes[2] = PokeName;
            }
            else
            {
                Console.WriteLine("Erro!!");
            }
        }
        public static void MascoteStatus(string PokeName)
        {

        }
        public static void MenuInicial(string userName)
        {
            Console.Clear();
            TView.Titulo();
            TView.MenuInicial(userName);

            int Escolha = int.Parse(Console.ReadLine());
            MenuSystem(userName, Escolha);
        }   
        public static void Adotar(string userName)
        {
            Console.Clear();
            TView.Titulo();
            TView.Adotar(userName);

            int Escolha = int.Parse(Console.ReadLine());
            string PokeName = "";
            int ID_Pokemon = 0;

            switch(Escolha)
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
                    MenuInicial(userName);
                    break;
                default:
                    Adotar(userName);
                    break;
            }
        }
        public static void AdotarInfo(string userName, string PokeName, int ID_Pokemon)
        {
            Console.Clear();
            TView.Titulo();
            TView.AdotarInfo(userName, PokeName);

            int Escolha = int.Parse(Console.ReadLine());

            switch(Escolha)
            {
                case 1:
                    APIControl.ConexaoAPI(userName, PokeName, ID_Pokemon);
                    break;
                case 2:
                    if(PossuiPokemon(PokeName) == true)
                    {
                        ConcluirAdocao(userName, PokeName);
                    }
                    else
                    {
                        Console.WriteLine("Pokemon já foi adotado!");
                        Thread.Sleep(3000);
                        AdotarInfo(userName, PokeName, ID_Pokemon);
                    }
                    break;
                case 3:
                    Adotar(userName);
                    break;
                default:
                    AdotarInfo(userName, PokeName, ID_Pokemon);
                    break;
            }
        }
        public static void ConcluirAdocao(string userName, string PokeName)
        {
            Console.Clear();

            TView.ConcluirAdocao(userName, PokeName);

            if(PokeName == "Bulbasaur")
            {
                UserModel.temBulbasaur = true;
                AtribuirMascote(PokeName);
            }
            else if (PokeName == "Charmander")
            {
                UserModel.temCharmander = true;
                AtribuirMascote(PokeName);
            }
            else if(PokeName == "Squirtle")
            {
                UserModel.temSquirtle = true;
                AtribuirMascote(PokeName);
            }

            int Escolher = 1;

            while (Escolher == 1)
            {
                int Escolha = int.Parse(Console.ReadLine());

                switch (Escolha)
                {
                    case 1:
                        Escolher = 0;
                        MenuInicial(userName);
                        break;
                    default:
                        Console.WriteLine("Opção Inválida!!");
                        break;
                }
            }
        }
        public static void MyMascotes(string userName)
        {

            Console.Clear();
            TView.Titulo();
            TView.MeusMascotes(UserModel.Mascotes[0], UserModel.Mascotes[1], UserModel.Mascotes[2]);

            int Escolha = int.Parse(Console.ReadLine());

            if(Escolha == 1)
            {
                if (UserModel.Mascotes[0] == "Bulbasaur")
                {
                    MascoteStatus("Bulbasaur");
                }
                else if (UserModel.Mascotes[0] == "Charmander")
                {
                    MascoteStatus("Charmander");
                }
                else if (UserModel.Mascotes[0] == "Squirtle")
                {
                    MascoteStatus("Squirtle");
                }
                else
                {
                    Console.WriteLine("Opção Inválida!!");
                    Thread.Sleep(2000);
                    MenuInicial(userName);
                }
            }
            else if(Escolha == 2)
            {
                if (UserModel.Mascotes[1] == "Bulbasaur")
                {
                    MascoteStatus("Bulbasaur");
                }
                else if (UserModel.Mascotes[1] == "Charmander")
                {
                    MascoteStatus("Charmander");
                }
                else if (UserModel.Mascotes[1] == "Squirtle")
                {
                    MascoteStatus("Squirtle");
                }
                else
                {
                    Console.WriteLine("Opção Inválida!!");
                    Thread.Sleep(2000);
                    MenuInicial(userName);
                }
            }
            else if(Escolha == 3)
            {
                if (UserModel.Mascotes[2] == "Bulbasaur")
                {
                    MascoteStatus("Bulbasaur");
                }
                else if (UserModel.Mascotes[2] == "Charmander")
                {
                    MascoteStatus("Charmander");
                }
                else if (UserModel.Mascotes[2] == "Squirtle")
                {
                    MascoteStatus("Squirtle");
                }
                else
                {
                    Console.WriteLine("Opção Inválida!!");
                    Thread.Sleep(2000);
                    MenuInicial(userName);
                }
            }
            else if(Escolha == 4)
            {
                MenuInicial(userName);
            } 
            else
            {
                Console.WriteLine("Opção Inválida!!");
                Thread.Sleep(2000);
                MenuInicial(userName);
            }
        }





    }
}
