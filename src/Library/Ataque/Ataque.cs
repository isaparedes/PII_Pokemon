namespace Library;

public class Ataque
{
    public Ataque(string nombre, int Dano, int Precision, string Tipo)
    {
        this.Nombre = nombre;
        this.Dano = Dano;
        this.Precision = Precision;
        this.Tipo = Tipo;
    }
    public string Nombre { get; protected set; }
    public string Tipo { get; protected set; }
    
    public int Dano { get; protected set; }
    public int Precision { get; protected set; }

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