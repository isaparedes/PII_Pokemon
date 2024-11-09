namespace Library;
/// <summary>
/// Esta es la clase abstracta Item. Los items podrán ser utilizados por los entrenadores en las batallas.
/// </summary>
public abstract class Item
{
    /// <summary>
    /// Obtiene o establece un string que indica el nombre del item.
    /// </summary>
    public string Nombre { get; protected set; }
    /// <summary>
    /// Obtiene o establece un string que indica la descripción del funcionamiento del item.
    /// </summary>
    public string Descripcion { get; protected set; }
   
}