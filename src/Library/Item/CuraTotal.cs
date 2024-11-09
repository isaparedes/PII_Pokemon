namespace Library;

public class CuraTotal: Item
{
    
    public CuraTotal()
    {
        this.Nombre = "Cura Total";
        this.Descripcion = "Cura a un Pokémon de efectos de ataques especiales";
    }
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