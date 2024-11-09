namespace Library;

public class Agua: Tipo
{
    public Agua()
    {
        this.Nombre = "Agua";
        this.Ataque = new Ataque("Tsunami", 30, 40, "Agua");
        this.AtaqueEspecial = new Incendio();
        this.debilContra.Add("Eléctrico");
        this.debilContra.Add("Planta");
        this.resistenteContra.Add("Agua");
        this.resistenteContra.Add("Fuego");
        this.resistenteContra.Add("Hielo");
    }
}