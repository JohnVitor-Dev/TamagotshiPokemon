using System;
using Newtonsoft.Json;
using Pokemon.Model;
using RestSharp;
using Tamagotshi.View;
using Pokemon.Model;
using API.Controller;

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
                    MyMascotes();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção Inválida!!");
                    break;
                }
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
                    TView.ConcluirAdocao(userName, PokeName);
                    break;
                case 3:
                    Adotar(userName);
                    break;
                default:
                    AdotarInfo(userName, PokeName, ID_Pokemon);
                    break;
            }
        }
        public static void MyMascotes()
        {
            Console.Clear();
            TView.Titulo();
            TView.MeusMascotes();
        }





    }
}
