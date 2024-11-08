namespace Library;
/// <summary>
/// Esta es la clase Ataque. Se encarga de crear instancias de ataques que usarán los Pokémons en la batalla.
/// </summary>
public class Ataque
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Ataque"/>.
    /// </summary>
    /// <param name="nombre">El nombre del ataque.</param>
    /// <param name="Dano">El daño que influye el ataque.</param>
    /// <param name="Precision">La precisión del ataque.</param>
    /// <param name="Tipo">El nombre del tipo de ataque.</param>
    public Ataque(string nombre, int Dano, int Precision, string Tipo)
    {
        this.Nombre = nombre;
        this.Dano = Dano;
        this.Precision = Precision;
        this.Tipo = Tipo;
    }
    /// <summary>
    /// Obtiene o establece un string que indica el nombre del ataque.
    /// </summary>
    public string Nombre { get; protected set; }
    /// <summary>
    /// Obtiene o establece un string que indica el tipo del ataque.
    /// </summary>
    public string Tipo { get; protected set; }
    /// <summary>
    /// Obtiene o establece un valor (int) que indica el daño del ataque.
    /// </summary>
    public int Dano { get; protected set; }
    /// <summary>
    /// Obtiene o establece un valor (int) que indica la precisión del ataque.
    /// </summary>
    public int Precision { get; protected set; }

    /// <summary>
    /// Calcula si el ataque es preciso, es decir, si hace o no daño/causa un efecto en la víctima.
    /// </summary>
    /// <returns>
    /// <c>0</c> si el ataque es preciso, <c>1</c> en caso contrario.
    /// </returns>
    public int CalcularPrecision()
    {
        Random numero = new Random();
        int ataca = numero.Next(1, 11);
        if (ataca > (this.Precision/10))
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}