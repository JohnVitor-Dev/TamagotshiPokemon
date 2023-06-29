using System;
using Newtonsoft.Json;
using Pokemon.Model;
using RestSharp;
using Tamagotshi.View;
using Pokemon.Model;

namespace Tamagotshi.Controller
{
    public static class TControl
    {
        public static void MenuSystem(string nome, int Escolha)
        {
            int jogar = 1;

            switch(Escolha)
            {
                case 1:
                    TView.Adotar(nome);
                    break;
                case 2:
                    TView.MeusMascotes();
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
            TControl.MenuSystem(userName, Escolha);
        }   





    }
}
