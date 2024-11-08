namespace Library;

public class Fantasma: Tipo
{
    public Fantasma()
    {
        this.Nombre = "Fantasma";
        this.Ataque = new Ataque("Danza", 10, 30,"Fantasma");
        this.AtaqueEspecial = new Incendio();
        this.debilContra.Add("Fantasma");
        this.resistenteContra.Add("Veneno");
        this.resistenteContra.Add("Lucha");
        this.resistenteContra.Add("Normal");
    }
}