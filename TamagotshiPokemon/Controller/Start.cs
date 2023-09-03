using System;
using Tamagotshi.Controller;
using Tamagotshi.View;
using Pokemon.Model;
using System.Reflection.Metadata;
using User.Model;
using Tamagotshi.Data;
using API.Controller;

namespace Start.Controller
{
    public static class TamagotshiPokemon
    {
        // Cria uma instância do Controller e do View
        static TContext _context = new TContext();
        static TView tView = new TView(tControl);
        static TControl tControl = new TControl(tView, _context);

        public static void Main()
        {
            APIControl _APIControl = new APIControl(tView, tControl);

            // Iniciar o Tamagotshi, selecionar ou criar um usuário.
            tControl.User();


            //Para o encerramento automático do console.
            string stop = Console.ReadLine();
        }
    }
}
