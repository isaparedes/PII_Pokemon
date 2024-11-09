namespace Library;

public class Pokemon
{
    public Pokemon(string nombre, Tipo tipo)
    {
        Nombre = nombre;
        Tipo = tipo;
        this.ataques.Add(tipo.Ataque);
        this.ataques.Add(tipo.AtaqueEspecial);
    }
    public string Nombre { get; protected set; }
    public Tipo Tipo { get; protected set; }
    private int vidaTotal = 80;
    public bool Dormido { get; set; }
    public bool Paralizado { get; set; }
    public bool Envenenado { get; set; }
    public bool Quemado { get; set; }
    public int TurnosDormido { get; set; }
    public List<Ataque> ataques = new List<Ataque>();

    public List<Ataque> GetAtaques()
    {
        return this.ataques;
    }
    
    public int VidaInicial {get { return 80; }}
    public int VidaTotal
    {
        get { return this.vidaTotal;}
        protected set { this.vidaTotal = value < 0 ? 0 : value; }
    }
    public void Curar(int puntos)
    {
        this.VidaTotal += puntos;
    }
    public void RecibirDano(int dano)
    {
        this.VidaTotal -= dano;
    }
    public List<string> GetDebilContra()
    {
        return this.Tipo.debilContra;
    }
    public List<string> GetResistenteContra()
    {
        return this.Tipo.resistenteContra;
    }
    public List<string> GetInmuneContra()
    {
        return this.Tipo.inmuneContra;
    }

    public string GetTipo()
    {
        return this.Tipo.Nombre;
    }

    
}