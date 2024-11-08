namespace Library;

public abstract class AtaqueEspecial: Ataque
{
    public AtaqueEspecial(string nombre, int dano, int precision, string tipo, string efecto): base(nombre,dano,precision,tipo)
    {
        this.Nombre = nombre;
        this.Dano = dano;
        this.Precision = precision;
        this.Tipo = tipo;
        this.Efecto = efecto;
    }
    public string Efecto { get; protected set; }
    
}
