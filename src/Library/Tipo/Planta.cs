namespace Library;

public class Planta: Tipo
{
    public Planta()
    {
        this.Nombre = "Planta";
        this.Ataque = new Ataque("Florecer", 10, 70,"Planta");
        this.AtaqueEspecial = new Off();
        this.debilContra.Add("Bicho");
        this.debilContra.Add("Fuego");
        this.debilContra.Add("Hielo");
        this.debilContra.Add("Veneno");
        this.debilContra.Add("Volador");
        this.resistenteContra.Add("Agua");
        this.resistenteContra.Add("Eléctrico");
        this.resistenteContra.Add("Planta");
        this.resistenteContra.Add("Tierra");
    }
}