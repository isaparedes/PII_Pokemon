namespace Library;
/// <summary>
/// Esta es la clase estática Efectividad. Se encarga de calcular la efectividad del ataque que recibe.
/// </summary>
public static class Efectividad
{
    /// <summary>
    /// Calcula qué tan efectivo es el ataque que recibe según su tipo y el tipo del Pokémon atacado.
    /// </summary>
    /// <param name="ataque">El ataque que se está utilizando.</param>
    /// <param name="pokemon">El Pokémon que está siendo atacado.</param>
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