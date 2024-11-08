namespace Library;
/// <summary>
/// Esta es la clase abstracta AtaqueEspecial. Hereda <see cref="Ataque"/> y agrega la propiedad Efecto.
/// </summary>

public abstract class AtaqueEspecial: Ataque
{
    /// <summary>
    /// Es un constructor que utilizarán las clases que la hereden.
    /// </summary>
    /// <param name="nombre">El nombre del ataque.</param>
    /// <param name="Dano">El daño que influye el ataque.</param>
    /// <param name="Precision">La precisión del ataque.</param>
    /// <param name="Tipo">El nombre del tipo de ataque.</param>
    /// <param name="Efecto">El nombre del efecto que realizará el ataque.</param>
    public AtaqueEspecial(string nombre, int dano, int precision, string tipo, string efecto): base(nombre,dano,precision,tipo)
    {
        this.Nombre = nombre;
        this.Dano = dano;
        this.Precision = precision;
        this.Tipo = tipo;
        this.Efecto = efecto;
    }
    /// <summary>
    /// Obtiene o establece un string que indica el nombre del Efecto
    /// </summary>
    public string Efecto { get; protected set; }
    
}