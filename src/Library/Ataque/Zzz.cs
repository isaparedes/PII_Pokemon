namespace Library;
/// <summary>
/// Esta es la clase Zzz. Hereda <see cref="AtaqueEspecial"/> y agrega el método Dormir.
/// </summary>

public class Zzz: AtaqueEspecial
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Zzz"/>.
    /// </summary>
    /// <param name="nombre">El nombre del ataque.</param>
    /// <param name="Dano">El daño que influye el ataque.</param>
    /// <param name="Precision">La precisión del ataque.</param>
    /// <param name="Tipo">El nombre del tipo de ataque.</param>
    /// <param name="Efecto">El nombre del efecto que realizará el ataque.</param>
    public Zzz() : base("Zzz", 0, 50, "Normal","Dormir")
    {
        
    }
    /// <summary>
    /// Le aplica el efecto "dormido" al pokemon que recibe.
    /// </summary>
    /// <param name="usuario">El entrenador que posee al Pokémon afectado.</param>
    /// <param name="pokemon">El Pokémon afectado.</param>
    /// <remarks>
    /// Se determina que el Pokémon permanezca dormido de 1 a 4 turnos aleatoriamente.
    /// </remarks>
    public void Dormir(Entrenador usuario, Pokemon pokemon)
    {
        pokemon.Dormido = true;
        Random turnosDormido = new Random();
        int turnos = turnosDormido.Next(1, 5);
        pokemon.TurnosDormido = usuario.Turnos += turnos;
    }
   
}