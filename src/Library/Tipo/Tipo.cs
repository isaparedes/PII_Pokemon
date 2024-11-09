namespace Library;
/// <summary>
/// Esta es la clase abstracta Tipo. Se encarga de determinar las propiedades que tendrán los tipos que la hereden.
/// </summary>
public abstract class Tipo
{
    /// <summary>
    /// Obtiene o establece un string que indica el nombre del Tipo.
    /// </summary>
    public string Nombre { get; protected set; }
    /// <summary>
    /// Obtiene o establece un string que indica el ataque que tiene este Tipo.
    /// </summary>
    public Ataque Ataque { get; protected set; }
    /// <summary>
    /// Obtiene o establece un string que indica el ataque especial que tiene este Tipo.
    /// </summary>
    public AtaqueEspecial AtaqueEspecial { get; protected set; }
    /// <summary>
    /// Atributo que indica la lista de tipos que son fuertes ante este tipo.
    /// </summary>
    public List<string> debilContra = new List<string>();
    /// <summary>
    /// Atributo que indica la lista de tipos que son débiles ante este tipo.
    /// </summary>
    public List<string> resistenteContra = new List<string>();
    /// <summary>
    /// Atributo que indica la lista de tipos que no generan daño ante este tipo.
    /// </summary>
    public List<string> inmuneContra = new List<string>();
}