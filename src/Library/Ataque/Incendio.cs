namespace Library;
/// <summary>
/// Esta es la clase Incendio. Hereda <see cref="AtaqueEspecial"/> y agrega el método Quemar.
/// </summary>
public class Incendio: AtaqueEspecial
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Incendio"/>.
    /// </summary>
    /// <param name="nombre">El nombre del ataque.</param>
    /// <param name="Dano">El daño que influye el ataque.</param>
    /// <param name="Precision">La precisión del ataque.</param>
    /// <param name="Tipo">El nombre del tipo de ataque.</param>
    /// <param name="Efecto">El nombre del efecto que realizará el ataque.</param>
    public Incendio() : base("Incendio", 10, 70, "Fuego","Quemar")
    {
        
    }
    /// <summary>
    /// Le aplica el efecto "quemado" al pokemon que recibe.
    /// </summary>
    /// <param name="pokemon">El Pokémon afectado.</param>
    /// <param name="critico">El número que indica si el ataque es crítico.</param>
    /// <remarks>
    /// El Pokémon recibe cierto daño según la efectividad del ataque y si es crítico
    /// </remarks>
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