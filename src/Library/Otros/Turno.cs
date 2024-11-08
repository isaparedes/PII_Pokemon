namespace Library;

public static class Turno
{
    public static void HacerAccion(Entrenador entrenador, string numero, Entrenador entrenadorAtacado, int usarRevivir,
        int usarSuperPocion, int usarCuraTotal)
    {
        Pokemon pokemonActual = entrenador.PokemonActual;
        Pokemon pokemonAtacado = entrenadorAtacado.PokemonActual;
        foreach (Pokemon pokemon in entrenador.miCatalogo)
        {
            if (pokemon.TurnosDormido == entrenador.Turnos)
                pokemon.Dormido = false;
        }

        if (pokemonActual.VidaTotal == 0 || pokemonActual.Dormido && numero == "0")
        {
            while (numero == "0")
            {
                Console.WriteLine("\nNo se puede elegir atacar, su pokemon está muerto o dormido. Elija otra opción");
                Consola.ElegirAccion();
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
                    Consola.ElegirAccion();
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

        if (pokemonActual.VidaTotal == 0)
        {
            entrenador.QuitarPokemon(pokemonActual);
            entrenador.AgregarMuerto(pokemonActual);
            Console.WriteLine($"\nTu pokemon {pokemonActual.Nombre} ha muerto");
            Console.WriteLine($"Puede cambiarlo o usar un item");
            Consola.ElegirAccion();
            numero = Console.ReadLine();
            while (numero == "0")
            {
                Console.WriteLine("Elija una opción válida");
                numero = Console.ReadLine();
            }
        }

        if (numero == "0")
        {
            int indiceAtaque;
            if (pokemonAtacado.Dormido || pokemonAtacado.Paralizado || pokemonAtacado.Envenenado ||
                pokemonAtacado.Quemado)
            {
                Consola.ElegirAtaqueSimple(pokemonActual);
                string ataque = Console.ReadLine();
                indiceAtaque = int.Parse(ataque);
            }
            else
            {
                Consola.ElegirAtaque(pokemonActual);
                string ataque = Console.ReadLine();
                indiceAtaque = int.Parse(ataque);
            }

            Random golpeCritico = new Random();
            int golpe = golpeCritico.Next(0, 10);
            int critico;
            if (golpe == 9)
            {
                critico = 0;
            }
            else
            {
                critico = 1;
            }

            if (pokemonActual.ataques[indiceAtaque] is AtaqueEspecial ataqueEspecial)
            {
                if (ataqueEspecial.CalcularPrecision() == 0)
                {

                    if (ataqueEspecial is Maniqui maniqui)
                    {
                        maniqui.Paralizar(pokemonAtacado);
                    }

                    if (ataqueEspecial is Incendio incendio)
                    {
                        incendio.Quemar(pokemonAtacado, critico);
                    }

                    if (ataqueEspecial is Off off)
                    {
                        off.Envenenar(pokemonAtacado, critico);
                    }

                    if (ataqueEspecial is Zzz zzz)
                    {
                        zzz.Dormir(entrenadorAtacado, pokemonAtacado);
                    }
                }

            }
            else
            {
                Ataque ataque = pokemonActual.ataques[indiceAtaque];
                if (ataque.CalcularPrecision() == 0) ;
                {
                    int dano = Efectividad.CalcularEfectividad(ataque, pokemonAtacado);
                    if (critico == 0)
                    {
                        dano *= 120 / 100;
                    }

                    pokemonAtacado.RecibirDano(dano);
                }
            }

            if (pokemonAtacado.VidaTotal == 0)
            {
                entrenadorAtacado.QuitarPokemon(pokemonAtacado);
                entrenadorAtacado.AgregarMuerto(pokemonAtacado);
            }
        }

        if (numero == "1")
        {
            Consola.ElegirPokemon(entrenador);
            string pokemon = Console.ReadLine();
            int pokemonElegido = int.Parse(pokemon);
            entrenador.PokemonActual = entrenador.miCatalogo[pokemonElegido];
        }

        if (numero == "2")
        {
            Consola.ElegirItem(entrenador);
            string item = Console.ReadLine();
            int itemElegido = int.Parse(item);
            if (entrenador.misItems[itemElegido] is Revivir && usarRevivir == 1)
            {
                while (entrenador.misItems[itemElegido] is Revivir)
                {
                    Console.WriteLine("\nDebes elegir otra opción. No hay pokemons muertos.");
                    Consola.ElegirItem(entrenador);
                    item = Console.ReadLine();
                    itemElegido = int.Parse(item);
                }
            }

            if (entrenador.misItems[itemElegido] is SuperPocion && usarSuperPocion == 1)
            {
                while (entrenador.misItems[itemElegido] is SuperPocion)
                {
                    Console.WriteLine("\nDebes elegir otra opción. No hay pokemons heridos.");
                    Consola.ElegirItem(entrenador);
                    item = Console.ReadLine();
                    itemElegido = int.Parse(item);
                }
            }

            if (entrenador.misItems[itemElegido] is CuraTotal && usarCuraTotal == 1)
            {
                while (entrenador.misItems[itemElegido] is CuraTotal)
                {
                    Console.WriteLine(
                        "\nDebes elegir otra opción. No hay pokemons bajo efectos de ataques especiales.");
                    Consola.ElegirItem(entrenador);
                    item = Console.ReadLine();
                    itemElegido = int.Parse(item);
                }
            }

            if (entrenador.misItems[itemElegido] is Revivir revivir)
            {
                Consola.ElegirPokemonMuerto(entrenador);
                string pokemonMuerto = Console.ReadLine();
                int pokemonElegido = int.Parse(pokemonMuerto);
                Pokemon pokemonARevivir = entrenador.misMuertos[pokemonElegido];
                revivir.RevivirPokemon(entrenador, pokemonARevivir);
            }
            else
            {
                Consola.ElegirPokemonHerido(entrenador, itemElegido);
                string _pokemon = Console.ReadLine();
                int pokemonElegido = int.Parse(_pokemon);
                Pokemon pokemon = entrenador.miCatalogo[pokemonElegido];
                if (entrenador.misItems[itemElegido] is CuraTotal curaTotal)
                {
                    curaTotal.CurarTotalmente(entrenador, pokemon);
                    if (entrenador.misItems[itemElegido] is SuperPocion superPocion)
                    {
                        superPocion.SuperPocionar(entrenador, pokemon);
                    }
                }
            }
            entrenador.MiTurno = false;
        }
    }
}