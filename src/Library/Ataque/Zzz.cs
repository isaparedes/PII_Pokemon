namespace Library;

public class Zzz: AtaqueEspecial
{
    public Zzz() : base("Zzz", 0, 50, "Normal","Dormir")
    {
        
    }
    public void Dormir(Entrenador usuario, Pokemon pokemon)
    {
        pokemon.Dormido = true;
        Random turnosDormido = new Random();
        int turnos = turnosDormido.Next(1, 5);
        pokemon.TurnosDormido = usuario.Turnos += turnos;
    }
   
}