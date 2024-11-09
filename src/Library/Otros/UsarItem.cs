namespace Library;

public static class UsarItem
{
    public static void UsoDeItem(Entrenador entrenador, int usarRevivir, int usarSuperPocion, int usarCuraTotal)
    {
        Facade.ElegirItem(entrenador);
        string item = Console.ReadLine();
        int itemElegido = int.Parse(item);
        if (entrenador.misItems[itemElegido] is Revivir && usarRevivir == 1)
        {
            while (entrenador.misItems[itemElegido] is Revivir)
            {
                Console.WriteLine("\nDebes elegir otra opción. No hay pokemons muertos.");
                Facade.ElegirItem(entrenador);
                item = Console.ReadLine();
                itemElegido = int.Parse(item);
            }
        }

        if (entrenador.misItems[itemElegido] is SuperPocion && usarSuperPocion == 1)
        {
            while (entrenador.misItems[itemElegido] is SuperPocion)
            {
                Console.WriteLine("\nDebes elegir otra opción. No hay pokemons heridos.");
                Facade.ElegirItem(entrenador);
                item = Console.ReadLine();
                itemElegido = int.Parse(item);

            }
        }

        if (entrenador.misItems[itemElegido] is CuraTotal && usarCuraTotal == 1)
        {
            while (entrenador.misItems[itemElegido] is CuraTotal)
            {
                Console.WriteLine("\nDebes elegir otra opción. No hay pokemons bajo efectos de ataques especiales.");
                Facade.ElegirItem(entrenador);
                item = Console.ReadLine();
                itemElegido = int.Parse(item);
            }
        }

        if (entrenador.misItems[itemElegido] is Revivir revivir)
        {
            Facade.ElegirPokemonMuerto(entrenador);
            string pokemonMuerto = Console.ReadLine();
            int pokemonElegido = int.Parse(pokemonMuerto);
            Pokemon pokemonARevivir = entrenador.misMuertos[pokemonElegido];
            revivir.RevivirPokemon(entrenador, pokemonARevivir);
        }
        else
        {
            Facade.ElegirPokemonHerido(entrenador, itemElegido);
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
    }
}