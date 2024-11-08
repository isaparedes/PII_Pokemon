namespace Library;

public abstract class Tipo
{
    public string Nombre { get; protected set; }
    public Ataque Ataque { get; protected set; }
    public AtaqueEspecial AtaqueEspecial { get; protected set; }
    public List<string> debilContra = new List<string>();
    public List<string> resistenteContra = new List<string>();
    public List<string> inmuneContra = new List<string>();
}