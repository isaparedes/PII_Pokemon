//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using ClassLibrary;

namespace Library
{
    /// <summary>
    /// Programa de consola de demostración.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main()
        {
            var train = new Train();
            train.StartEngines();
            Console.WriteLine("Hello World!");
            Entrenador vanesa = new Entrenador("vanesa");
            Entrenador victoria = new Entrenador("victoria");
            vanesa.AgregarPokemon("Pikachu");
            vanesa.AgregarPokemon("Skarmory");
            vanesa.AgregarPokemon("Rockruff");
            vanesa.AgregarPokemon("Vulpix");
            vanesa.AgregarPokemon("Charmander");
            vanesa.AgregarPokemon("Vanillite");
            victoria.AgregarPokemon("Pikachu");
            victoria.AgregarPokemon("Bulbasaur");
            victoria.AgregarPokemon("Squirtle");
            victoria.AgregarPokemon("Ponyta");
            victoria.AgregarPokemon("Eevee");
            victoria.AgregarPokemon("Greavard");
            Batalla batalla = new Batalla(vanesa, victoria);
            batalla.Comenzar();

        }
    }
}