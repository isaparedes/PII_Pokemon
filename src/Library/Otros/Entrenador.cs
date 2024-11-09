using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Library
{
    /// <summary>
    /// Esta es la clase Entrenador. Se encarga de crear instancias de Entrenador y gestionar sus responsabilidades.
    /// </summary>
    public class Entrenador
    {
        /// <summary>
        /// Obtiene o establece el nombre del entrenador.
        /// </summary>
        public string Nombre { get; private set; }
        /// <summary>
        /// Atributo tipo List que contiene los Pokémons vivos del entrenador.
        /// </summary>
        public List<Pokemon> miCatalogo = new List<Pokemon>();
        /// <summary>
        /// Atributo tipo List que contiene los Pokémons muertos del entrenador.
        /// </summary>
        public List<Pokemon> misMuertos = new List<Pokemon>();
        /// <summary>
        /// Atributo tipo List que contiene los items del entrenador.
        /// </summary>
        public List<Item> misItems = new List<Item>();
        /// <summary>
        /// Obtiene o establece un bool que indica si es o no el turno del entrenador.
        /// </summary>
        public bool MiTurno { get; set; }
        /// <summary>
        /// Obtiene o establece un valor (int) que indica la cantiad de turnos del entrenador.
        /// </summary>
        public int Turnos { get; set; }
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Entrenador"/>.
        /// </summary>
        /// <param name="nombre">El nombre del entrenador.</param>
        public Entrenador(string nombre)
        {
            this.Nombre = nombre;
        }
        /// <summary>
        /// Agrega un Pokémon al catálogo del entrenador.
        /// </summary>
        /// <param name="pokemon">Pokémon que se agrega.</param>
        public void AgregarPokemon(Pokemon pokemon)
        {
            if (this.miCatalogo.Count < 6 && !this.miCatalogo.Contains(pokemon) && !Batalla.EnBatalla)
            {
                
                miCatalogo.Add(pokemon);
            }
            else
            {
                Console.WriteLine("No se puede agregar el Pokémon. Verifica que no esté ya en el catálogo o que no hayas alcanzado el límite.");
            }
        }
        /// <summary>
        /// Quita un Pokémon del catálogo del entrenador.
        /// </summary>
        /// <param name="pokemon">Pokémon que es quitado.</param>
        public void QuitarPokemon(Pokemon pokemon)
        {
            if (this.miCatalogo.Contains(pokemon))
            {
                this.miCatalogo.Remove(pokemon);
            }
        }

        /// <summary>
        /// Agrega un item al catálogo del entrenador.
        /// </summary>
        /// <param name="item">item que se agrega.</param>
        public void AgregarItem(Item item)
        {
            if (Batalla.EnBatalla)
            {
                this.misItems.Add(item);
            }
        }

        /// <summary>
        /// Quita un item del catálogo del entrenador.
        /// </summary>
        /// <param name="item">item que es quitado.</param>
        public void QuitarItem(Item item)
        {
            if (this.misItems.Contains(item))
            {
                this.misItems.Remove(item);
            }
        }

        /// <summary>
        /// Agrega a un Pokémon al catálogo de muertos.
        /// </summary>
        /// <param name="pokemon">Pokémon que es agregado.</param>
        public void AgregarMuerto(Pokemon pokemon)
        {
            if (!this.misMuertos.Contains(pokemon))
            {
                this.misMuertos.Add(pokemon);
            }
        }
        /// <summary>
        /// Quita a un Pokémon del catálogo de muertos.
        /// </summary>
        /// <param name="pokemon">Pokémon que es quitado.</param>
        public void QuitarMuerto(Pokemon pokemon)
        {
            this.misMuertos.Remove(pokemon);
        }

        /// <summary>
        /// Agrega al catálogo un Pokémon que fue reivivido.
        /// </summary>
        /// <param name="pokemon">Pokémon que es agregado.</param>
        public void Recuperar(Pokemon pokemon)
        {
            this.miCatalogo.Add(pokemon);
        }
        
        /// <summary>
        /// Obtiene o establece el Pokémon actual
        /// </summary>
        public Pokemon PokemonActual { get; set; }
    }
}