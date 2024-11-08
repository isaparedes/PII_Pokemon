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

        public void ElegirPokemon(Entrenador usuario)
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

        public void ElegirAtaque(Pokemon pokemon)
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

        public void ElegirItem(Entrenador usuario)
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

        public void ElegirPokemonMuerto(Entrenador usuario)
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

        public void ElegirPokemonHerido(Entrenador usuario, int itemElegido)
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

        public void MostrarMetodosBatalla()
        {
            Console.WriteLine("\nMétodos disponibles en la clase Batalla:");
            Console.WriteLine("1. Comenzar: Comienza la batalla entre dos entrenadores.");
        }

        public void MostrarMetodosTurno()
        {
            Console.WriteLine("\nMétodos disponibles en la clase Turno:");
            Console.WriteLine("1. HacerAccion: Realiza una acción en el turno del entrenador.");
        }
    }
}
