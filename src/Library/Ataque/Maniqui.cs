namespace Library;

public class Maniqui: AtaqueEspecial
{
    public Maniqui() : base("Maniquí", 0, 80, "Psíquico","Paralizar")
    {
        
    }

    public void Paralizar(Pokemon pokemon)
    {
        pokemon.Paralizado = true;
    }
    
}