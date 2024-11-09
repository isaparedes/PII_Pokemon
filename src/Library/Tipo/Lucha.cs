namespace Library;

public class Lucha: Tipo
{
    public Lucha()
    {
        this.Nombre = "Lucha";
        this.Ataque = new Ataque("Golpe", 40, 40,"Lucha");
        this.AtaqueEspecial = new Off();
        this.debilContra.Add("Psíquico");
        this.debilContra.Add("Volador");
        this.debilContra.Add("Bicho");
        this.debilContra.Add("Roca");
    }
}