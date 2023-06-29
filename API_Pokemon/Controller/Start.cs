using System;
using Tamagotshi.Controller;
using Tamagotshi.View;
using Pokemon.Model;
using System.Reflection.Metadata;
using User.Model;

public static class TamagotshiPokemon
{
    public static void Main()
    {
        // Iniciar o Tamagotshi pegando o nome de usuário.
        TView.Titulo();
        TView.GetName();
        UserModel.User user = new UserModel.User();
        user.user = Console.ReadLine();




        //MenuInicial(nameUsuario);
    }
}
