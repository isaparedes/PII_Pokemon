namespace Library;
/// <summary>
/// Esta es la clase SuperPocion. Hereda <see cref="Item"/> y agrega el método SuperPocionar
/// </summary>
public class SuperPocion: Item
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="SuperPocion"/>.
    /// </summary>
    public SuperPocion()
    {
        this.Nombre = "Súper Poción";
        this.Descripcion = "Recupera 70 puntos de vida";
    }
    /// <summary>
    /// Le suma 70 puntos de vida a un Pokémon o la vida que le falta para volver a tener la vida inicial.
    /// </summary>
    /// <param name="entrenador">El entrenador que posee al Pokémon a curar.</param>
    /// <param name="pokemon">El Pokémon a curar.</param>
    public void SuperPocionar(Entrenador entrenador, Pokemon pokemon)
    {
        if (pokemon.VidaTotal + 70 <= pokemon.VidaInicial) 
            pokemon.Curar(70);
        else
        {
            pokemon.Curar(pokemon.VidaInicial - pokemon.VidaTotal);
        }
        entrenador.QuitarItem(this);
    }
}