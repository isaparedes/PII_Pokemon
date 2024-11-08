namespace Library;

public class Tierra: Tipo
{
    public Tierra()
    {
        this.Nombre = "Tierra";
        this.Ataque = new Ataque("Terremoto", 40, 30,"Tierra");
        this.AtaqueEspecial = new Incendio();
        this.debilContra.Add("Agua");
        this.debilContra.Add("Hielo");
        this.debilContra.Add("Planta");
        this.debilContra.Add("Roca");
        this.debilContra.Add("Veneno");
        this.resistenteContra.Add("Electrico");
    }
}