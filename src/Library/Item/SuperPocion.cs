namespace Library;

public class SuperPocion: Item
{
    
    public SuperPocion()
    {
        this.Nombre = "Súper Poción";
        this.Descripcion = "Recupera 70 puntos de vida";
    }
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