namespace Library;
/// <summary>
/// Esta es la clase estática Pokedex. Se encarga de tener todos los Pokémons disponibles para usar.
/// </summary>
public static class Pokedex
{
    /// <summary>
    /// Atributo estático tipo Lista que contiene todos los Pokémons disponibles.
    /// </summary>
    public static List<Pokemon> listaPokemons = new List<Pokemon>
    {
        new Pokemon("Bulbasaur", new Planta()), new Pokemon("Caterpie", new Bicho()),
        new Pokemon("Charmander", new Fuego()), new Pokemon("Cranidos", new Roca()),
        new Pokemon("Cubone", new Tierra()), new Pokemon("Darumaka", new Hielo()),
        new Pokemon("Diglett", new Tierra()), new Pokemon("Dratini", new Dragon()),
        new Pokemon("Duskull", new Fantasma()), new Pokemon("Eevee", new Normal()),
        new Pokemon("Goomy", new Dragon()), new Pokemon("Greavard", new Fantasma()),
        new Pokemon("Koffing", new Veneno()), new Pokemon("Machop", new Lucha()),
        new Pokemon("Mew", new Psiquico()), new Pokemon("Nidoran", new Veneno()),
        new Pokemon("Oddish", new Planta()), new Pokemon("Pikachu", new Electrico()),
        new Pokemon("Ponyta", new Psiquico()), new Pokemon("Psyduck", new Agua()),
        new Pokemon("Rockruff", new Roca()), new Pokemon("Skarmory", new Volador()),
        new Pokemon("Snorlax", new Normal()), new Pokemon("Squirtle", new Agua()),
        new Pokemon("Timburr", new Lucha()), new Pokemon("Vanillite", new Hielo()),
        new Pokemon("Voltorb", new Electrico()), new Pokemon("Vullaby", new Volador()),
        new Pokemon("Vulpix", new Fuego()), new Pokemon("Wurmple", new Bicho())
    };
    /// <summary>
    /// Se encarga de buscar un Pokémon en la Pokédex por su nombre.
    /// </summary>
    /// <param name="nombre">El nombre del Pokémon a buscar.</param>
    public static Pokemon BuscarPokemon(string nombre)
    {
        foreach (Pokemon pokemon in listaPokemons)
        {
            if (pokemon.Nombre == nombre)
            {
                return Pokedex.CrearCopia(pokemon);
             
            }
        }
        return null;
    }
    /// <summary>
    /// Se encarga de crear una copia profunda del Pokémon que recibe.
    /// </summary>
    /// <param name="pokemon">El Pokémon que se copia.</param>
    public static Pokemon CrearCopia(Pokemon pokemon)
    {
        string nombreCopia = pokemon.Nombre;
        
        if (pokemon.Tipo is Agua)
            return new Pokemon(nombreCopia, new Agua());
        if (pokemon.Tipo is Bicho)
            return new Pokemon(nombreCopia, new Bicho());
        if (pokemon.Tipo is Dragon)
            return new Pokemon(nombreCopia, new Dragon());
        if (pokemon.Tipo is Electrico)
            return new Pokemon(nombreCopia, new Electrico());
        if (pokemon.Tipo is Fantasma)
            return new Pokemon(nombreCopia, new Fantasma());
        if (pokemon.Tipo is Fuego)
            return new Pokemon(nombreCopia, new Fuego());
        if (pokemon.Tipo is Hielo)
            return new Pokemon(nombreCopia, new Hielo());
        if (pokemon.Tipo is Lucha)
            return new Pokemon(nombreCopia, new Lucha());
        if (pokemon.Tipo is Normal)
            return new Pokemon(nombreCopia, new Normal());
        if (pokemon.Tipo is Planta)
            return new Pokemon(nombreCopia, new Planta());
        if (pokemon.Tipo is Psiquico)
            return new Pokemon(nombreCopia, new Psiquico());
        if (pokemon.Tipo is Roca)
            return new Pokemon(nombreCopia, new Roca());
        if (pokemon.Tipo is Tierra)
            return new Pokemon(nombreCopia, new Tierra());
        if (pokemon.Tipo is Veneno)
            return new Pokemon(nombreCopia, new Veneno());
        if (pokemon.Tipo is Volador)
            return new Pokemon(nombreCopia, new Volador());
        return null;
    }
    
}