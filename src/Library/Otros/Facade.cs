using System;
using System.Collections.Generic;

namespace Library
{
    public class Facade
    {
        /*
        User Stories:
        1. Como jugador, quiero seleccionar 6 Pokémon de un catálogo para que participen en la batalla.
        2. Como jugador, quiero que mi Pokémon ataque al Pokémon del oponente.
        3. Como jugador, quiero que mi Pokémon use un ataque especial que pueda causar efectos como dormir, paralizar, envenenar o quemar.
        4. Como jugador, quiero que los Pokémon tengan un nombre y un tipo.
        5. Como jugador, quiero que los ataques tengan un nombre, un tipo y un daño específico.
        6. Como jugador, quiero que los Pokémon puedan ser afectados por ataques especiales y que estos efectos se mantengan hasta el final de la batalla, a menos que se use un ítem de cura total.
        7. Como jugador, quiero que los Pokémon puedan perder HP debido a ataques y efectos de estado.
        8. Como jugador, quiero que los ítems puedan ser utilizados durante la batalla, pero que al usarlos, pierda mi turno.
        9. Como jugador, quiero que los ítems disponibles sean: 4 Súper pociones, 1 Revivir y 2 Cura total.
        10. Como jugador, quiero que el juego se desarrolle en turnos alternos entre los dos jugadores.
        11. Como jugador, quiero que el juego termine cuando uno de los jugadores no tenga Pokémon vivos.
        */

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
            Batalla batalla = new Batalla(jugador1, jugador2, this);
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
                        jugador.AgregarPokemon(pokemonsDisponibles[seleccion]);
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

        public void RealizarAccion(Entrenador jugador, Entrenador oponente)
        {
            while (true)
            {
                ElegirAccion();
                int accion = int.Parse(Console.ReadLine());

                switch (accion)
                {
                    case 0: // Atacar
                        Atacar.Encuentro(jugador, oponente);
                        break;
                    case 1: // Cambiar Pokémon
                        CambiarPokemon.CambioDePokemon(jugador);
                        break;
                    case 2: // Usar ítem
                        UsarItem.UsoDeItem(jugador, 1, 1, 1); // Aquí puedes ajustar la lógica para los ítems
                        break;
                    case 3: // Ver datos del jugador
                        MostrarDatosJugador(jugador);
                        break;
                    default:
                        Console.WriteLine("Acción no válida. Intenta de nuevo.");
                        break;
                }
            }
        }

        // Métodos de Consola trasladados a Facade

        public void ElegirAccion()
        {
            Console.WriteLine("\n==================================");
            Console.WriteLine("LISTA DE ACCIONES (Seleccione según el número):");
            Console.WriteLine("\t0 - Atacar");
            Console.WriteLine("\t1 - Cambiar Pokémon");
            Console.WriteLine("\t2 - Usar ítem");
            Console.WriteLine("\t3 - Ver datos del jugador");
            Console.WriteLine("==================================");
        }

        public static void ElegirPokemon(Entrenador usuario)
        {
            Console.WriteLine("\n==================================");
            Console.WriteLine("LISTA DE POKEMONES DISPONIBLES (Seleccione según el número):");
            for (int i = 0; i < usuario.miCatalogo.Count; i++)
            {
                Pokemon pokemon = usuario.miCatalogo[i];
                Console.WriteLine($"\t{i} - \"{pokemon.Nombre}\" de Tipo: {pokemon.GetTipo()}");
            }
            Console.WriteLine("==================================");
        }

        public static void ElegirAtaque(Pokemon pokemon)
        {
            Console.WriteLine($"\n==================================");
            Console.WriteLine($"LISTA DE ATAQUES DISPONIBLES DE {pokemon.Nombre} (Seleccione según el número):");
            for (int i = 0; i < pokemon.ataques.Count; i++)
            {
                Ataque ataque = pokemon.ataques[i];
                string mensaje = $"\t{i} - \"{ataque.Nombre}\" / Tipo: {ataque.Tipo} / Daño: {ataque.Dano} / Precisión: {ataque.Precision}";
                if (ataque is AtaqueEspecial ataqueEspecial)
                {
                    mensaje += $" / (Especial) Efecto: {ataqueEspecial.Efecto}";
                }
                Console.WriteLine(mensaje);
            }
            Console.WriteLine("==================================");
        }

        public static void ElegirAtaqueSimple(Pokemon pokemon)
        {
            Console.WriteLine($"\n==================================");
            Console.WriteLine($"LISTA DE ATAQUES SIMPLES DISPONIBLES DE {pokemon.Nombre} (Seleccione según el número):");

            // Suponiendo que los ataques simples están en una lista separada o que todos los ataques son simples
            for (int i = 0; i < pokemon.ataques.Count; i++)
            {
                Ataque ataque = pokemon.ataques[i];
                // Aquí puedes filtrar si el ataque es simple, si tienes una propiedad que lo indique
                string mensaje = $"\t{i} - \"{ataque.Nombre}\" / Tipo: {ataque.Tipo} / Daño: {ataque.Dano} / Precisión: {ataque.Precision}";
                Console.WriteLine(mensaje);
            }
    
            Console.WriteLine("==================================");
        }
        public static void ElegirItem(Entrenador usuario)
        {
            Console.WriteLine($"\n==================================");
            Console.WriteLine($"LISTA DE ÍTEMS DISPONIBLES DE {usuario.Nombre} (Seleccione según el número):");
            for (int i = 0; i < usuario.misItems.Count; i++)
            {
                Item item = usuario.misItems[i];
                Console.WriteLine($"\t{i} - \"{item.Nombre}\" ({item.Descripcion})");
            }
            Console.WriteLine("==================================");
        }

        public void ImprimirDatos(Entrenador usuario)
        {
            Console.WriteLine($"\n==================================");
            Console.WriteLine($"DATOS DE POKEMONES DE JUGADOR {usuario.Nombre}:");
            foreach (Pokemon pokemon in usuario.miCatalogo)
            {
                string mensaje = $"\t\"{pokemon.Nombre}\" / Vida: {pokemon.VidaTotal}";
                if (pokemon.Dormido) mensaje += " / Efecto: dormido";
                if (pokemon.Paralizado) mensaje += " / Efecto: paralizado";
                if (pokemon.Envenenado) mensaje += " / Efecto: envenenado";
                if (pokemon.Quemado) mensaje += " / Efecto: quemado";
                Console.WriteLine(mensaje);
            }
            Console.WriteLine("==================================");
        }

        public static void ElegirPokemonMuerto(Entrenador usuario)
        {
            Console.WriteLine("\n==================================");
            Console.WriteLine("LISTA DE POKEMONES MUERTOS DISPONIBLES (Seleccione según el número):");
            for (int i = 0; i < usuario.misMuertos.Count; i++)
            {
                Pokemon pokemon = usuario.misMuertos[i];
                Console.WriteLine($"\t{i} - \"{pokemon.Nombre}\" de Tipo: {pokemon.GetTipo()}");
            }
            Console.WriteLine("==================================");
        }

        public static void ElegirPokemonHerido(Entrenador usuario, int itemElegido)
        {
            Console.WriteLine("\n==================================");
            Console.WriteLine("LISTA DE POKEMONES HERIDOS DISPONIBLES (Seleccione según el número):");
            for (int i = 0; i < usuario.miCatalogo.Count; i++)
            {
                Pokemon pokemon = usuario.miCatalogo[i];
                if (pokemon.VidaTotal < pokemon.VidaInicial)
                {
                    Console.WriteLine($"\t{i} - \"{pokemon.Nombre}\" de Tipo: {pokemon.GetTipo()}");
                }
            }
            Console.WriteLine("==================================");
        }

        public static void MostrarMetodosBatalla()
        {
            Console.WriteLine("\nMétodos disponibles en la clase Batalla:");
            Console.WriteLine("1. Comenzar: Comienza la batalla entre dos entrenadores.");
        }
        

        public static void MostrarMetodosTurno()
        {
            Console.WriteLine("\nMétodos disponibles en la clase Turno:");
            Console.WriteLine("1. HacerAccion: Realiza una acción en el turno del entrenador.");
        }

        private static void MostrarDatosJugador(Entrenador jugador)
        {
            Console.WriteLine("\n==================================");
            Console.WriteLine($"Datos de {jugador.Nombre}:");
            Console.WriteLine("Pokémon seleccionados:");

            foreach (var pokemon in jugador.miCatalogo)
            {
                Console.WriteLine($"- {pokemon.Nombre} (Tipo: {pokemon.Tipo})");
            }

            Console.WriteLine("==================================\n");
        }
    }
}