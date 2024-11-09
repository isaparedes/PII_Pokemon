namespace Library;
/// <summary>
/// Esta es la clase CuraTotal. Hereda <see cref="Item"/> y agrega el método CurarTotalmente.
/// </summary>
public class CuraTotal: Item
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="CuraTotal"/>.
    /// </summary>
    public CuraTotal()
    {
        this.Nombre = "Cura Total";
        this.Descripcion = "Cura a un Pokémon de efectos de ataques especiales";
    }
    /// <summary>
    /// Cura a un Pokémon de los efectos de ataques especiales.
    /// </summary>
    /// <param name="entrenador">El entrenador que posee al Pokémon a curar.</param>
    /// <param name="pokemon">El Pokémon a curar.</param>
    public void CurarTotalmente(Entrenador entrenador, Pokemon pokemon)
    {
        if (pokemon.Dormido)
        {
            pokemon.Dormido = false;
        }
        if (pokemon.Paralizado)
        {
            pokemon.Paralizado = false;
        }
        if (pokemon.Envenenado)
        {
            pokemon.Envenenado = false;
        }
        if (pokemon.Quemado)
        {
            pokemon.Quemado = false;
        }
        entrenador.QuitarItem(this);
    }
}