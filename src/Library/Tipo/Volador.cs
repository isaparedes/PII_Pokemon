namespace Library;

public class Volador: Tipo
{
    public Volador()
    {
        this.Nombre = "Volador";
        this.Ataque = new Ataque("Viento", 25, 50,"Volador");
        this.AtaqueEspecial = new Maniqui();
        this.debilContra.Add("Eléctrico");
        this.debilContra.Add("Hielo");
        this.debilContra.Add("Roca");
        this.resistenteContra.Add("Bicho");
        this.resistenteContra.Add("Lucha");
        this.resistenteContra.Add("Planta");
        this.resistenteContra.Add("Tierra");
    }
}