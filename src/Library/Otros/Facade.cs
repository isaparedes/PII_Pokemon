using System;
using System.Collections.Generic;

namespace Library
{
    public class Facade
    {
        private Entrenador jugador1;
        private Entrenador jugador2;

        public Facade(string nombreJugador1, string nombreJugador2)
        {
            jugador1 = new Entrenador(nombreJugador1);
            jugador2 = new Entrenador(nombreJugador2);
        }

        public void ComenzarBatalla()
        {
            InicializarPokemon(jugador1);
            InicializarPokemon(jugador2);
            Batalla batalla = new Batalla(jugador1, jugador2);
            batalla.Comenzar();
        }

        private void InicializarPokemon(Entrenador jugador)
        {
            Console.WriteLine($"Selecciona 6 Pokémon para {jugador.Nombre}:");
            List<Pokemon> pokemonsDisponibles = Pokedex.listaPokemons;

            for (int i = 0; i < pokemonsDisponibles.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {pokemonsDisponibles[i].Nombre}");
            }

            HashSet<string> seleccionados = new HashSet<string>();

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"Selecciona el Pokémon {i + 1} (1-{pokemonsDisponibles.Count}):");
                int seleccion = int.Parse(Console.ReadLine()) - 1;

                if (seleccion >= 0 && seleccion < pokemonsDisponibles.Count)
                {
                    string nombrePokemon = pokemonsDisponibles[seleccion].Nombre;

                    if (!seleccionados.Contains(nombrePokemon))
                    {
                        jugador.AgregarPokemon(nombrePokemon);
                        seleccionados.Add(nombrePokemon);
                    }
                    else
                    {
                        Console.WriteLine("Ya has seleccionado este Pokémon. Intenta de nuevo.");
                        i--;
                    }
                }
                else
                {
                    Console.WriteLine("Selección no válida. Intenta de nuevo.");
                    i--;
                }
            }
        }

        public void RealizarAccion(Entrenador jugador)
        {
            while (true)
            {
                MostrarOpcionesAccion();
                int accion = int.Parse(Console.ReadLine());

                switch (accion)
                {
                    case 0:
                        // Atacar
                        // Lógica de ataque aquí
                        break;
                    case 1:
                        // Cambiar Pokémon
                        MostrarPokemon(jugador);
                        // Lógica para cambiar Pokémon aquí
                        break;
                    case 2:
                        // Usar ítem
                        MostrarItems(jugador);
                        int itemSeleccionado = int.Parse(Console.ReadLine());
                        Item item = jugador.misItems[itemSeleccionado];

                        if (item is ItemCuracion curacionItem)
                        {
                            Pokemon pokemonAcurar = ObtenerPokemonParaCurar(jugador);
                            if (pokemonAcurar.VidaTotal < pokemonAcurar.VidaInicial)
                            {
                                pokemonAcurar.Curar(curacionItem.Cantidad);
                                Console.WriteLine($"{pokemonAcurar.Nombre} ha sido curado.");
                            }
                            else
                            {
                                Console.WriteLine("No puedes curar a un Pokémon que ya tiene vida máxima.");
                                continue;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Acción no válida. Intenta de nuevo.");
                        break;
                }
                break;
            }
        }

        private void MostrarOpcionesAccion()
        {
            Console.WriteLine("\n==================================");
            Console.WriteLine("LISTA DE ACCIONES (Seleccione según el número):");
            Console.WriteLine("\t0 - Atacar");
            Console.WriteLine("\t1 - Cambiar Pokémon");
            Console.WriteLine("\t2 - Usar ítem");
            Console.WriteLine("==================================");
        }

        private void MostrarPokemon(Entrenador jugador)
        {
            Console.WriteLine("\n==================================");
            Console.WriteLine("LISTA DE POKEMONES DISPONIBLES (Seleccione según el número):");
            for (int i = 0; i < jugador.miCatalogo.Count; i++)
            {
                Pokemon pokemon = jugador.miCatalogo[i];
                Console.Write Console.WriteLine($"\t{i} - \"{pokemon.Nombre}\" de Tipo: {pokemon.GetTipo()}");
            }
            Console.WriteLine("==================================");
        }

        private void MostrarItems(Entrenador jugador)
        {
            Console.WriteLine("\n==================================");
            Console.WriteLine($"LISTA DE ÍTEMS DISPONIBLES DE {jugador.Nombre} (Seleccione según el número):");
            for (int i = 0; i < jugador.misItems.Count; i++)
            {
                Item item = jugador.misItems[i];
                Console.WriteLine($"\t{i} - \"{item.Nombre}\" ({item.Descripcion})");
            }
            Console.WriteLine("==================================");
        }

        private Pokemon ObtenerPokemonParaCurar(Entrenador jugador)
        {
            MostrarPokemonHerido(jugador);
            int seleccion = int.Parse(Console.ReadLine());
            return jugador.miCatalogo[seleccion];
        }

        private void MostrarPokemonHerido(Entrenador jugador)
        {
            Console.WriteLine("\n==================================");
            Console.WriteLine("LISTA DE POKEMONES HERIDOS DISPONIBLES (Seleccione según el número):");
            for (int i = 0; i < jugador.miCatalogo.Count; i++)
            {
                Pokemon pokemon = jugador.miCatalogo[i];
                if (pokemon.VidaTotal < pokemon.VidaInicial)
                {
                    Console.WriteLine($"\t{i} - \"{pokemon.Nombre}\" de Tipo: {pokemon.GetTipo()}");
                }
            }
            Console.WriteLine("==================================");
        }
    }
}