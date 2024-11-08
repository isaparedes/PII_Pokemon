namespace Library;

public static class CambiarPokemon
{
    public static void CambioDePokemon(Entrenador entrenador)
    {
        Consola.ElegirPokemon(entrenador);
        string pokemon = Console.ReadLine();
        int pokemonElegido = int.Parse(pokemon);
        entrenador.PokemonActual = entrenador.miCatalogo[pokemonElegido];
    }
}