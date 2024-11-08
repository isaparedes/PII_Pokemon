namespace Library
{
    public static class Consola
    {
        // Muestra las opciones de acción disponibles para el jugador
        public static void ElegirAccion()
        {
            Console.WriteLine("\n==================================");
            Console.WriteLine("LISTA DE ACCIONES (Seleccione según el número):");
            Console.WriteLine("\t0 - Atacar");
            Console.WriteLine("\t1 - Cambiar Pokémon");
            Console.WriteLine("\t2 - Usar ítem");
            Console.WriteLine("==================================");
        }

        // Muestra la lista de Pokémon disponibles del entrenador
        public static void ElegirPokemon(Entrenador usuario)
        {
            Console.WriteLine("\n==================================");
            Console.WriteLine("LISTA DE POKEMONES DISPONIBLES (Seleccione según el número):");
            for (int i = 0; i < usuario.miCatalogo.Count; i++)
            {
                Pokemon pokemon = usuario.miCatalogo[i];
                Console.WriteLine($"\t{i} - \"{pokemon.Nombre}\" de Tipo: {pokemon.GetTipo()}");
            }
            Console.WriteLine("==================================");
        }

        // Muestra la lista de ataques disponibles del Pokémon
        public static void ElegirAtaque(Pokemon pokemon)
        {
            Console.WriteLine($"\n==================================");
            Console.WriteLine($"LISTA DE ATAQUES DISPONIBLES DE {pokemon.Nombre} (Seleccione según el número):");
            for (int i = 0; i < pokemon.ataques.Count; i++)
            {
                Ataque ataque = pokemon.ataques[i];
                string mensaje = $"\t{i} - \"{ataque.Nombre}\" / Tipo: {ataque.Tipo} / Daño: {ataque.Dano} / Precisión: {ataque.Precision}";
                if (ataque is AtaqueEspecial ataqueEspecial)
                {
                    mensaje += $" / (Especial) Efecto: {ataqueEspecial.Efecto}";
                }
                Console.WriteLine(mensaje);
            }
            Console.WriteLine("==================================");
        }

        // Muestra la lista de ítems disponibles del entrenador
        public static void ElegirItem(Entrenador usuario)
        {
            Console.WriteLine($"\n==================================");
            Console.WriteLine($"LISTA DE ÍTEMS DISPONIBLES DE {usuario.Nombre} (Seleccione según el número):");
            for (int i = 0; i < usuario.misItems.Count; i++)
            {
                Item item = usuario.misItems[i];
                Console.WriteLine($"\t{i} - \"{item.Nombre}\" ({item.Descripcion})");
            }
            Console.WriteLine("==================================");
        }

        // Muestra los datos de los Pokémon del entrenador
        public static void ImprimirDatos(Entrenador usuario)
        {
            Console.WriteLine($"\n==================================");
            Console.WriteLine($"DATOS DE POKEMONES DE JUGADOR {usuario.Nombre}:");
            foreach (Pokemon pokemon in usuario.miCatalogo)
            {
                string mensaje = $"\t\"{pokemon.Nombre}\" / Vida: {pokemon.VidaTotal}";
                if (pokemon.Dormido) mensaje += " / Efecto: dormido";
                if (pokemon.Paralizado) mensaje += " / Efecto: paralizado";
                if (pokemon.Envenenado) mensaje += " / Efecto: envenenado";
                if (pokemon.Quemado) mensaje += " / Efecto: quemado";
                Console.WriteLine(mensaje);
            }
            Console.WriteLine("==================================");
        }

        // Muestra la lista de Pokémon muertos del entrenador
        public static void ElegirPokemonMuerto(Entrenador usuario)
        {
            Console.WriteLine("\n==================================");
            Console.WriteLine("LISTA DE POKEMONES MUERTOS DISPONIBLES (Seleccione según el número):");
            for (int i = 0; i < usuario.misMuertos.Count; i++)
            {
                Pokemon pokemon = usuario.misMuertos[i];
                Console.WriteLine($"\t{i} - \"{pokemon.Nombre}\" de Tipo: {pokemon.GetTipo()}");
            }
            Console.WriteLine("==================================");
        }

        // Muestra la lista de Pokémon heridos del entrenador
        public static void ElegirPokemonHerido(Entrenador usuario, int itemElegido)

        {
            Console.WriteLine("\n==================================");
            Console.WriteLine("LISTA DE POKEMONES HERIDOS DISPONIBLES (Seleccione según el número):");
            for (int i = 0; i < usuario.miCatalogo.Count; i++)
            {
                Pokemon pokemon = usuario.miCatalogo[i];
                if (pokemon.VidaTotal < pokemon.VidaInicial)
                {
                    Console.WriteLine($"\t{i} - \"{pokemon.Nombre}\" de Tipo: {pokemon.GetTipo()}");
                }
            }
            Console.WriteLine("==================================");
        }

        // Método para mostrar los métodos de la clase Batalla
        public static void MostrarMetodosBatalla()
        {
            Console.WriteLine("\nMétodos disponibles en la clase Batalla:");
            Console.WriteLine("1. Comenzar: Comienza la batalla entre dos entrenadores.");
        }

        // Método para mostrar los métodos de la clase Turno
        public static void MostrarMetodosTurno()
        {
            Console.WriteLine("\nMétodos disponibles en la clase Turno:");
            Console.WriteLine("1. HacerAccion: Realiza una acción en el turno del entrenador.");
        }
    }
}