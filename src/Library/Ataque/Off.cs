namespace Library;
/// <summary>
/// Esta es la clase Off. Hereda <see cref="AtaqueEspecial"/> y agrega el método Envenenar.
/// </summary>

public class Off: AtaqueEspecial
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Off"/>.
    /// </summary>
    /// <param name="nombre">El nombre del ataque.</param>
    /// <param name="Dano">El daño que influye el ataque.</param>
    /// <param name="Precision">La precisión del ataque.</param>
    /// <param name="Tipo">El nombre del tipo de ataque.</param>
    /// <param name="Efecto">El nombre del efecto que realizará el ataque.</param>
    public Off() : base("Off", 10, 90, "Veneno","Envenenar")
    {
        
    }
    /// <summary>
    /// Le aplica el efecto "envenenado" al Pokémon que recibe.
    /// </summary>
    /// <param name="pokemon">El Pokémon afectado.</param>
    /// <param name="critico">El número que indica si el ataque es crítico.</param>
    /// <remarks>
    /// El Pokémon recibe cierto daño según la efectividad del ataque y si es crítico
    /// </remarks>
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