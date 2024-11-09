namespace Library;

public class Hielo: Tipo
{
    public Hielo()
    {
        this.Nombre = "Hielo";
        this.Ataque = new Ataque("Iceberg", 20, 60,"Hielo");
        this.AtaqueEspecial = new Maniqui();
        this.debilContra.Add("Fuego");
        this.debilContra.Add("Lucha");
        this.debilContra.Add("Roca");
        this.resistenteContra.Add("Hielo");
    }
}