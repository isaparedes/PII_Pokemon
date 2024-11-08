namespace Library;

public static class Atacar
{
    public static void Encuentro(Entrenador atacante, Entrenador victima)
    {
        Pokemon pokemonActual = atacante.PokemonActual;
        Pokemon pokemonAtacado = victima.PokemonActual;
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
                    zzz.Dormir(victima, pokemonAtacado);
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
            victima.QuitarPokemon(pokemonAtacado);
            victima.AgregarMuerto(pokemonAtacado);
        }
    }
}