namespace Library;

public static class Turno
{
    public static void HacerAccion(Entrenador entrenador, string numero, Entrenador entrenadorAtacado, 
        int usarRevivir, int usarSuperPocion, int usarCuraTotal, Facade facade)
    {
        Pokemon pokemonActual = entrenador.PokemonActual;
        Pokemon pokemonAtacado = entrenadorAtacado.PokemonActual;
        if (pokemonActual.VidaTotal == 0)
        {
            entrenador.QuitarPokemon(pokemonActual);
            entrenador.AgregarMuerto(pokemonActual);
            Console.WriteLine($"\nTu pokemon {pokemonActual.Nombre} ha muerto");
            Console.WriteLine($"Puede cambiarlo o usar un item");
            facade.ElegirAccion();
            numero = Console.ReadLine();
            while (numero == "0")
            {
                Console.WriteLine("Elija una opción válida");
                numero = Console.ReadLine();
            }
        }
        foreach (Pokemon pokemon in entrenador.miCatalogo)
        {
            if (pokemon.TurnosDormido == entrenador.Turnos)
                pokemon.Dormido = false;
        }

        if (pokemonActual.Dormido && numero == "0")
        {
            while (numero == "0")
            {
                Console.WriteLine("\nNo se puede elegir atacar, su pokemon está dormido. Elija otra opción");
                facade.ElegirAccion();
                numero = Console.ReadLine();
            }
        }

        if (pokemonActual.Paralizado && numero == "0")
        {
            Random poderAtacar = new Random();
            int randomPoderAtacar = poderAtacar.Next(0, 3);
            if (randomPoderAtacar != 0)
            {
                while (numero == "0")
                {
                    Console.WriteLine("\nNo se puede elegir atacar, su pokemon esta paralizado. Elija otra opción");
                    facade.ElegirAccion();
                    numero = Console.ReadLine();
                }
            }
        }

        foreach (Pokemon pokemon in entrenador.miCatalogo)
        {
            if (pokemon.Envenenado)
            {
                pokemon.RecibirDano(pokemon.VidaTotal * 5 / 100);

            }

            if (pokemon.Quemado)
            {
                pokemon.RecibirDano(pokemon.VidaTotal * 10 / 100);
            }
        }
        if (numero == "0")
        {
          Atacar.Encuentro(entrenador,entrenadorAtacado);
        }

        if (numero == "1")
        {
            CambiarPokemon.CambioDePokemon(entrenador);
        }

        if (numero == "2")
        {
         UsarItem.UsoDeItem(entrenador,usarRevivir,usarSuperPocion,usarCuraTotal);
        } 
        entrenador.MiTurno = false;
    }
}