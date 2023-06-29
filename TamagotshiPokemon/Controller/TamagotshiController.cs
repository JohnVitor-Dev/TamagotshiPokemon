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

            while (jogar == 1)
            {
                switch(Escolha)
                {
                    case 1:
                        TView.Adotar(nome);
                        break;
                    case 2:
                        TView.MeusMascotes();
                        break;
                    case 3:
                        jogar = 0;
                        break;
                    default:
                        Console.WriteLine("Opção Inválida!!");
                        break;
                }
            }
        }

        public static void MenuInicial()
        {
            TView.MenuInicial(PokemonModel)
        }   





    }
}
