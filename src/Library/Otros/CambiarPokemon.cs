namespace Library;
/// <summary>
/// Esta es la clase estática CambiarPokemon. Se encarga de gestionar la acción del mismo nombre durante la batalla.
/// </summary>
public static class CambiarPokemon
{
    /// <summary>
    /// Le asigna un nuevo Pokémon actual al jugador que recibe.
    /// </summary>
    /// <param name="entrenador">El jugador al que se le cambia el Pokémon actual.</param>
    public static void CambioDePokemon(Entrenador entrenador)
    {
        Facade.ElegirPokemon(entrenador);
        string pokemon = Console.ReadLine();
        int pokemonElegido = int.Parse(pokemon);
        entrenador.PokemonActual = entrenador.miCatalogo[pokemonElegido];
    }
}