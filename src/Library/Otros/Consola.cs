namespace Library;

public static class Consola
{
  public static void ElegirAccion()
  {
    Console.WriteLine("\nLISTA DE ACCIONES (Seleccione según el número):");
    Console.WriteLine("\t0 - Atacar");
    Console.WriteLine("\t1 - Cambiar Pokemon");
    Console.WriteLine("\t2 - Usar item");
  }

  public static void ElegirPokemon(Entrenador usuario)
  {
    Console.WriteLine("\nLISTA DE POKEMONES DISPONIBLES (Seleccione según el número):");
    for (int i = 0; i < usuario.miCatalogo.Count; i++)
    {
      Pokemon pokemon = usuario.miCatalogo[i];
      if (pokemon != usuario.PokemonActual)
        Console.WriteLine($"\t{i} - ¨{pokemon.Nombre}¨ de Tipo: {pokemon.GetTipo()}");
    }
  }

  public static void ElegirAtaque(Pokemon pokemon) //user story 2
  {
    Console.WriteLine($"\nLISTA DE ATAQUES DISPONIBLES DE {pokemon.Nombre} (Seleccione según el número:");
    for (int i = 0; i < pokemon.ataques.Count; i++)
    {
      Ataque ataque = pokemon.ataques[i];
      string mensaje =
        $"\t{i} - ¨{ataque.Nombre}¨/Tipo: {ataque.Tipo}/Daño: {ataque.Dano}/Precision: {ataque.Precision}";
      if (ataque is AtaqueEspecial ataqueEspecial)
      {
        mensaje += $"/(Especial)Efecto: {ataqueEspecial.Efecto}";
      }

      Console.WriteLine(mensaje);
    }
  }

  public static void ElegirAtaqueSimple(Pokemon pokemon) //user story 2
  {
    Console.WriteLine(
      $"\nEl pokemon a atacar está bajo algún efecto de ataques especiales. Solo puede atacar con ataques simples");
    Console.WriteLine($"LISTA DE ATAQUES SIMPLES DISPONIBLES DE {pokemon.Nombre} (Seleccione según el número):");
    for (int i = 0; i < pokemon.ataques.Count; i++)
    {
      Ataque ataque = pokemon.ataques[i];
      if (ataque is not AtaqueEspecial)
      {
        Console.WriteLine(
          $"\t{i} - ¨{ataque.Nombre}¨/Tipo: {ataque.Tipo}/Daño: {ataque.Dano}/Precision: {ataque.Precision}");
      }
    }
  }

  public static void ElegirItem(Entrenador usuario)
  {
    Console.WriteLine($"\nLISTA DE ITEMS DISPONIBLES DE {usuario.Nombre} (Seleccione según el número):");
    for (int i = 0; i < usuario.misItems.Count; i++)
    {
      Item item = usuario.misItems[i];
      Console.WriteLine($"\t{i} - ¨{item.Nombre}¨({item.Descripcion})");
    }
  }

  public static void ElegirPokemonMuerto(Entrenador usuario)
  {
    Console.WriteLine("\nLISTA DE POKEMONES MUERTOS DISPONIBLES (Seleccione según el número):");
    for (int i = 0; i < usuario.misMuertos.Count; i++)
    {
      Pokemon pokemon = usuario.misMuertos[i];
      Console.WriteLine($"\t{i} - ¨{pokemon.Nombre}¨ de Tipo: {pokemon.GetTipo()}");
    }
  }

  public static void ElegirPokemonHerido(Entrenador usuario, int itemElegido)
  {
    Console.WriteLine("\nLISTA DE POKEMONES HERIDOS DISPONIBLES (Seleccione según el número):");
    for (int i = 0; i < usuario.miCatalogo.Count; i++)
    {
      Pokemon pokemon = usuario.miCatalogo[i];
      if (usuario.misItems[itemElegido] is CuraTotal && pokemon.Dormido || pokemon.Paralizado || pokemon.Envenenado || pokemon.Quemado)
        Console.WriteLine($"\t{i} - ¨{pokemon.Nombre}¨ de Tipo: {pokemon.GetTipo()}");
      else if (usuario.misItems[itemElegido] is not CuraTotal && pokemon.VidaTotal < pokemon.VidaInicial)
        Console.WriteLine($"\t{i} - ¨{pokemon.Nombre}¨ de Tipo: {pokemon.GetTipo()}");
    }
  }

  public static void ImprimirDatos(Entrenador usuario, Entrenador usuario2)
  {
    
    Console.WriteLine($"\nDATOS DE POKEMONES DE JUGADOR {usuario.Nombre}:\n");
    {
      Console.WriteLine($"\tVIVOS:"); 
      foreach (Pokemon pokemon in usuario.miCatalogo)
      {
        string mensaje = $"\t¨{pokemon.Nombre}/Vida: {pokemon.VidaTotal}";
        if (pokemon.Dormido)
          mensaje += $"/Efecto: dormido";
        if (pokemon.Paralizado)
          mensaje += $"/Efecto: paralizado";
        if (pokemon.Envenenado)
          mensaje += $"/Efecto: envenenado";
        if (pokemon.Quemado)
          mensaje += $"/Efecto: quemado";
        if (pokemon == usuario.PokemonActual)
          mensaje += $" (Pokemon actual)";
        Console.WriteLine(mensaje);
      }
      Console.WriteLine($"\n");
      Console.WriteLine($"\tMUERTOS:");
      if (usuario.misMuertos.Count == 0)
      {
        Console.WriteLine($"\t(No hay muertos)");
      }
      else
      {
        foreach (Pokemon pokemonMuerto in usuario.misMuertos)
        {
          Console.WriteLine($"\t¨{pokemonMuerto.Nombre}/Vida: {pokemonMuerto.VidaTotal}");
        }  
      }
    }
    
    Console.WriteLine($"\nDATOS DE POKEMONES DE JUGADOR {usuario2.Nombre}:\n");
    {
      Console.WriteLine($"\tVIVOS:"); 
      foreach (Pokemon pokemon in usuario2.miCatalogo)
      {
        string mensaje = $"\t¨{pokemon.Nombre}/Vida: {pokemon.VidaTotal}";
        if (pokemon.Dormido)
          mensaje += $"/Efecto: dormido";
        if (pokemon.Paralizado)
          mensaje += $"/Efecto: paralizado";
        if (pokemon.Envenenado)
          mensaje += $"/Efecto: envenenado";
        if (pokemon.Quemado)
          mensaje += $"/Efecto: quemado";
        if (pokemon == usuario2.PokemonActual)
          mensaje += $" (Pokemon actual)";
        Console.WriteLine(mensaje);
      }
      Console.WriteLine($"\n");
      Console.WriteLine($"\tMUERTOS:");
      if (usuario2.misMuertos.Count == 0)
      {
        Console.WriteLine($"\t(No hay muertos)");
      }
      else
      {
        foreach (Pokemon pokemonMuerto in usuario2.misMuertos)
        {
          Console.WriteLine($"\t¨{pokemonMuerto.Nombre}/Vida: {pokemonMuerto.VidaTotal}");
        }  
      }
    }
  }
}