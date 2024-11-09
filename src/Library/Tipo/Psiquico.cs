namespace Library;

public class Psiquico: Tipo
{
    public Psiquico()
    {
        this.Nombre = "Psiquico";
        this.Ataque = new Ataque("Hipnosis", 30, 80, "Psíquico");
        this.AtaqueEspecial = new Zzz();
        this.debilContra.Add("Bicho");
        this.debilContra.Add("Lucha");
        this.debilContra.Add("Fantasma");
    }
}