namespace Library;

public class Veneno: Tipo
{
    public Veneno()
    {
        this.Nombre = "Veneno";
        this.Ataque = new Ataque("Cicuta", 30, 90,"Veneno");
        this.AtaqueEspecial = new Incendio();
        this.debilContra.Add("Bicho");
        this.debilContra.Add("Psíquico");
        this.debilContra.Add("Tierra");
        this.debilContra.Add("Lucha");
        this.debilContra.Add("Planta");
        this.resistenteContra.Add("Veneno");
    }
}