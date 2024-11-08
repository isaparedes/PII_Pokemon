namespace Library;

public class Normal: Tipo
{
    
    public Normal()
    {
        this.Nombre = "Normal";
        this.Ataque = new Ataque("Patada", 30, 50,"Normal");
        this.AtaqueEspecial = new Maniqui();
        this.debilContra.Add("Lucha");
        this.inmuneContra.Add("Fantasma");
    }
}