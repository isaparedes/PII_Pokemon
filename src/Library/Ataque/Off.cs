namespace Library;

public class Off: AtaqueEspecial
{
    public Off() : base("Off", 10, 90, "Veneno","Envenenar")
    {
        
    }

    public void Envenenar(Pokemon pokemon, int critico)
    {
        pokemon.Envenenado = true;
        pokemon.RecibirDano(pokemon.VidaTotal*5/100);
        int dano = Efectividad.CalcularEfectividad(new Off(), pokemon);
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