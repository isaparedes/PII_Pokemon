namespace Library;

public class Bicho: Tipo
{
    public Bicho()
    {
        this.Nombre = "Bicho";
        this.Ataque = new Ataque("Mordisco", 15, 70,"Bicho");
        this.AtaqueEspecial = new Off();
        this.debilContra.Add("Fuego");
        this.debilContra.Add("Roca");
        this.debilContra.Add("Volador");
        this.debilContra.Add("Veneno");
        this.resistenteContra.Add("Lucha");
        this.resistenteContra.Add("Planta");
        this.resistenteContra.Add("Tierra");
    }
}