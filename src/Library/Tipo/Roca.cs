namespace Library;

public class Roca: Tipo
{
    public Roca()
    {
        this.Nombre = "Roca";
        this.Ataque = new Ataque("Derrumbe", 35, 50,"Roca");
        this.AtaqueEspecial = new Zzz();
        this.debilContra.Add("Agua");
        this.debilContra.Add("Lucha");
        this.debilContra.Add("Planta");
        this.debilContra.Add("Tierra");
        this.resistenteContra.Add("Fuego");
        this.resistenteContra.Add("Normal");
        this.resistenteContra.Add("Veneno");
        this.resistenteContra.Add("Volador");
    }
}