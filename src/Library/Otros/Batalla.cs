namespace Library;

public class Batalla
{
    public static bool EnBatalla;
    public Entrenador Jugador1 { get; private set; }
    public Entrenador Jugador2 { get; private set; }

    public Batalla(Entrenador jugador1, Entrenador jugador2)
    {
        EnBatalla = true;
        this.Jugador1 = jugador1;
        this.Jugador1.AgregarItem(new SuperPocion());
        this.Jugador1.AgregarItem(new SuperPocion());
        this.Jugador1.AgregarItem(new SuperPocion());
        this.Jugador1.AgregarItem(new SuperPocion());
        this.Jugador1.AgregarItem(new Revivir());
        this.Jugador1.AgregarItem(new CuraTotal());
        this.Jugador1.AgregarItem(new CuraTotal());
        
        this.Jugador2 = jugador2;
        this.Jugador2.AgregarItem(new SuperPocion());
        this.Jugador2.AgregarItem(new SuperPocion());
        this.Jugador2.AgregarItem(new SuperPocion());
        this.Jugador2.AgregarItem(new SuperPocion());
        this.Jugador2.AgregarItem(new Revivir());
        this.Jugador2.AgregarItem(new CuraTotal());
        this.Jugador2.AgregarItem(new CuraTotal());
    }

    public void Comenzar()
    {
        if (Jugador1.miCatalogo.Count == 6 && Jugador2.miCatalogo.Count == 6)
        {
            Random primerPokemonJ1 = new Random();
            int pokemonRandom1 = primerPokemonJ1.Next(0, 6);
            Jugador1.PokemonActual = Jugador1.miCatalogo[pokemonRandom1];
            Random primerPokemonJ2 = new Random();
            int pokemonRandom2 = primerPokemonJ2.Next(0, 6);
            Jugador2.PokemonActual = Jugador2.miCatalogo[pokemonRandom2];
            while (Jugador1.miCatalogo.Count > 0 && Jugador2.miCatalogo.Count > 0 && EnBatalla)
            {
                Jugador1.MiTurno = true;
                Jugador1.Turnos += 1;
                Consola.ImprimirDatos(Jugador1);
                Consola.ImprimirDatos(Jugador2);   
                Console.WriteLine($"\nTURNO JUGADOR 1: {Jugador1.Nombre}");
                Consola.ElegirAccion();
                int usarRevivir1 = 1;
                int usarSuperPocion1 = 1;
                int usarCuraTotal1 = 1;
                for (int i = 0; i < Jugador1.miCatalogo.Count; i++)
                {
                    Pokemon pokemon = Jugador1.miCatalogo[i];
                    if (pokemon.VidaTotal < pokemon.VidaInicial)
                    {
                        usarSuperPocion1 = 0;
                    }
                    if (pokemon.Dormido || pokemon.Paralizado || pokemon.Envenenado || pokemon.Quemado)
                    {
                        usarCuraTotal1 = 0;
                    }
                }
                if (Jugador1.misMuertos.Count > 0)
                    usarRevivir1 = 0;
                
                string accion1 = Console.ReadLine();
                if (usarRevivir1 == 1 || usarSuperPocion1 == 1 || usarCuraTotal1 == 1)
                {
                    while (accion1 == "2")
                    {
                        Console.WriteLine("No puedes usar un item. Elige otra acción.");
                        Consola.ElegirAccion();
                        accion1 = Console.ReadLine();
                    }
                }
                Turno.HacerAccion(Jugador1,accion1,Jugador2,usarRevivir1,usarSuperPocion1,usarCuraTotal1);
                Jugador2.MiTurno = true;
                Jugador2.Turnos += 1;
                if (Jugador2.miCatalogo.Count == 0 && Jugador2.misItems.OfType<Revivir>().Any() == false)
                {
                    EnBatalla = false;
                }
                else
                {
                    Consola.ImprimirDatos(Jugador1);
                    Consola.ImprimirDatos(Jugador2);    
                    Console.WriteLine($"\nTURNO JUGADOR 2: {Jugador2.Nombre}");
                    Consola.ElegirAccion();
                    int usarRevivir2 = 1;
                    int usarSuperPocion2 = 1;
                    int usarCuraTotal2 = 1;
                    for (int i = 0; i < Jugador2.miCatalogo.Count; i++)
                    {
                        Pokemon pokemon = Jugador2.miCatalogo[i];
                        if (pokemon.VidaTotal < pokemon.VidaInicial)
                        {
                            usarSuperPocion2 = 0;
                        }

                        if (pokemon.Dormido || pokemon.Paralizado || pokemon.Envenenado || pokemon.Quemado)
                        {
                            usarCuraTotal2 = 0;
                        }
                    }
                    if (Jugador2.misMuertos.Count > 0)
                        usarRevivir2 = 0;
                
                    string accion2 = Console.ReadLine();
                    if (usarRevivir2 == 1 && usarSuperPocion2 == 1 && usarCuraTotal2 == 1)
                    {
                        while (accion2 == "2")
                        {
                            Console.WriteLine("No puedes usar un item. Elige otra acción.");
                            Consola.ElegirAccion();
                            accion2 = Console.ReadLine();
                        }
                    }
                    Turno.HacerAccion(Jugador2,accion2,Jugador1,usarRevivir2,usarSuperPocion2,usarCuraTotal2);
                }
                if (Jugador1.misItems.OfType<Revivir>().Any() == false)
                {
                    EnBatalla = false;
                }


            }
        }
    }
    
    
    
}