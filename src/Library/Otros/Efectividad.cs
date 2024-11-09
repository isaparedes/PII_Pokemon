namespace Library;

public static class Efectividad
{
    public static int CalcularEfectividad(Ataque ataque, Pokemon pokemon)
    {
        int danoFinal = ataque.Dano;
        if (pokemon.GetDebilContra().Contains(ataque.Tipo))
        {
            danoFinal = ataque.Dano*2;
        }
        if (pokemon.GetResistenteContra().Contains(ataque.Tipo))
        {
            danoFinal = ataque.Dano / 2;
        }

        if (pokemon.GetInmuneContra().Contains(ataque.Tipo))
        {
            danoFinal = 0;
        }

        return danoFinal;
    }
}