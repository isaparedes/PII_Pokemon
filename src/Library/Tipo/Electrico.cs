using System.Data;

namespace Library;

public class Electrico: Tipo
{
    public Electrico()
    {
        this.Nombre = "Eléctrico";
        this.Ataque = new Ataque("Rayo", 40, 20,"Eléctrico");
        this.AtaqueEspecial = new Zzz();
        this.debilContra.Add("Tierra");
        this.resistenteContra.Add("Volador");
        this.inmuneContra.Add("Electrico");
    }
}