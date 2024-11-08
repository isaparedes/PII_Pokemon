namespace Library;

public class Revivir: Item
{
    public Revivir()
    {
        this.Nombre = "Revivir";
        this.Descripcion = "Revive a un Pokémon con el 50% de su vida total";
    }
    public void RevivirPokemon(Entrenador entrenador,Pokemon pokemon)
    {
        pokemon.Curar(pokemon.VidaInicial/2);
        entrenador.QuitarMuerto(pokemon);
        entrenador.Recuperar(pokemon);
        if (entrenador.PokemonActual.VidaTotal == 0)
        {
            entrenador.PokemonActual = pokemon;
        }
        
        entrenador.QuitarItem(this);
    } 
}