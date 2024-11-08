namespace Library;

public class Fuego: Tipo
{
    public Fuego()
    {
        this.Nombre = "Fuego";
        this.Ataque = new Ataque("Fogata", 45, 70,"Fuego");
        this.AtaqueEspecial = new Off();
        this.debilContra.Add("Agua");
        this.debilContra.Add("Roca");
        this.debilContra.Add("Tierra");
        this.resistenteContra.Add("Bicho");
        this.resistenteContra.Add("Fuego");
        this.resistenteContra.Add("Planta");
    }
}