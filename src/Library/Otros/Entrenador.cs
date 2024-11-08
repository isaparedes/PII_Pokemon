using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Library
{
    public class Entrenador
    {
        public string Nombre { get; private set; }
        public List<Pokemon> miCatalogo = new List<Pokemon>();
        public List<Pokemon> misMuertos = new List<Pokemon>();
        public List<Item> misItems = new List<Item>();
        public bool MiTurno { get; set; }
        public int Turnos { get; set; }

        public Entrenador(string nombre)
        {
            this.Nombre = nombre;
        }

        // Método para agregar un Pokémon al catálogo
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

        // Método para quitar un Pokémon del catálogo
        public void QuitarPokemon(Pokemon pokemon)
        {
            if (this.miCatalogo.Contains(pokemon))
            {
                this.miCatalogo.Remove(pokemon);
            }
        }

        // Método para agregar un ítem
        public void AgregarItem(Item item)
        {
            if (Batalla.EnBatalla)
            {
                this.misItems.Add(item);
            }
        }

        // Método para quitar un ítem
        public void QuitarItem(Item item)
        {
            if (this.misItems.Contains(item))
            {
                this.misItems.Remove(item);
            }
        }

        // Método para agregar un Pokémon a la lista de muertos
        public void AgregarMuerto(Pokemon pokemon)
        {
            if (!this.misMuertos.Contains(pokemon))
            {
                this.misMuertos.Add(pokemon);
            }
        }

        // Método para quitar un Pokémon de la lista de muertos
        public void QuitarMuerto(Pokemon pokemon)
        {
            this.misMuertos.Remove(pokemon);
        }

        // Método para recuperar un Pokémon
        public void Recuperar(Pokemon pokemon)
        {
            this.miCatalogo.Add(pokemon);
        }

        // Propiedad para el Pokémon actual
        public Pokemon PokemonActual { get; set; }
    }
}