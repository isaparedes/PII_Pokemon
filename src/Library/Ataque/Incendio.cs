namespace Library;

public class Incendio: AtaqueEspecial
{
    public Incendio() : base("Incendio", 10, 70, "Fuego","Quemar")
    {
        
    }
    public void Quemar(Pokemon pokemon, int critico)
    {
        pokemon.Quemado = true;
        pokemon.RecibirDano(pokemon.VidaTotal*10/100);
        int dano = Efectividad.CalcularEfectividad(new Incendio(), pokemon);
        if (critico == 0)
        {
            pokemon.RecibirDano(dano*120/100);
        }
        else
        {
            pokemon.RecibirDano(dano);
        }
    
    }
   
}