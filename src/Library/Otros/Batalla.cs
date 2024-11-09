namespace Library
{
    /// <summary>
    /// Esta es la clase estática Batalla. Se encarga de crear instancias de batalla, y gestionar los turnos y acciones de los jugadores.
    /// </summary>
    public class Batalla
    {
        /// <summary>
        /// Atributo estático booleano de batalla que indica si está siendo ejecutada alguna batalla.
        /// </summary>
        public static bool EnBatalla;
        /// <summary>
        /// Obtiene o establece un Entrenador que indica el Jugador 1.
        /// </summary>
        public Entrenador Jugador1 { get; private set; }
        /// <summary>
        /// Obtiene o establece un Entrenador que indica el Jugador 2.
        /// </summary>
        public Entrenador Jugador2 { get; private set; }
        /// <summary>
        /// Atributo Facade que indica la instancia de fachada.
        /// </summary>
        private Facade facade;
        
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Batalla"/>.
        /// </summary>
        /// <param name="jugador1">El usuario que será el Jugador 1.</param>
        /// <param name="jugador2">El usuario que será el Jugador 2.</param>
        /// <param name="facade">La instancia de fachada.</param>
        public Batalla(Entrenador jugador1, Entrenador jugador2, Facade facade)
        {
            EnBatalla = true;
            this.Jugador1 = jugador1;
            this.Jugador2 = jugador2;
            this.facade = facade;

            InicializarItems(Jugador1);
            InicializarItems(Jugador2);
        }
        /// <summary>
        /// Le agrega al jugador los items con los que contará durante la batalla.
        /// </summary>
        /// <param name="jugador">El jugador al que se le agregan los items.</param>
        private void InicializarItems(Entrenador jugador)
        {
            jugador.AgregarItem(new SuperPocion());
            jugador.AgregarItem(new SuperPocion());
            jugador.AgregarItem(new SuperPocion());
            jugador.AgregarItem(new SuperPocion());
            jugador.AgregarItem(new Revivir());
            jugador.AgregarItem(new CuraTotal());
            jugador.AgregarItem(new CuraTotal());
        }
        /// <summary>
        /// Da comienzo a una batalla
        /// </summary>
        public void Comenzar()
        {
            if (Jugador1.miCatalogo.Count == 6 && Jugador2.miCatalogo.Count == 6)
            {
                AsignarPokemonInicial(Jugador1);
                AsignarPokemonInicial(Jugador2);

                while (Jugador1.miCatalogo.Count > 0 && Jugador2.miCatalogo.Count > 0 && EnBatalla)
                {
                    TurnoJugador(Jugador1, Jugador2);
                    if (!EnBatalla) break;
                    TurnoJugador(Jugador2, Jugador1);
                }
            }
        }
        /// <summary>
        /// Le asigna al jugador un Pokémon aleatorio de su catálogo para atacar.
        /// </summary>
        /// <param name="jugador">El jugador al que se le asigna el Pokémon.</param>
        private void AsignarPokemonInicial(Entrenador jugador)
        {
            Random random = new Random();
            int pokemonRandom = random.Next(0, 6);
            jugador.PokemonActual = jugador.miCatalogo[pokemonRandom];
        }
        /// <summary>
        /// Da comienzo al turno del jugador
        /// </summary>
        /// <param name="jugadorActual">El jugador que dará comienzo a su turno.</param>
        /// <param name="oponente">El jugador que no estará en su turno.</param>
        private void TurnoJugador(Entrenador jugadorActual, Entrenador oponente)
        {
            jugadorActual.MiTurno = true;
            jugadorActual.Turnos += 1;
            facade.ImprimirDatos(jugadorActual);
            facade.ImprimirDatos(oponente);
            Console.WriteLine($"\nTURNO {jugadorActual.Nombre}:");
            facade.ElegirAccion();

            string accion = Console.ReadLine();
            ValidarAcciones(jugadorActual, accion, oponente);
        }
        /// <summary>
        /// Valida la acción que ingresó el jugador como la deseada y realiza una acción válida.
        /// </summary>
        /// <param name="jugador">El jugador que está decidiendo la acción a seguir.</param>
        /// <param name="accion">La acción que ingresó el jugador como la deseada.</param>
        /// <param name="oponente">El jugador que no está en su turno.</param>
        private void ValidarAcciones(Entrenador jugador, string accion, Entrenador oponente)
        {
            int usarRevivir = 1;
            int usarSuperPocion = 1;
            int usarCuraTotal = 1;

            foreach (var pokemon in jugador.miCatalogo)
            {
                if (pokemon.VidaTotal < pokemon.VidaInicial) usarSuperPocion = 0;
                if (pokemon.Dormido || pokemon.Paralizado || pokemon.Envenenado || pokemon.Quemado) usarCuraTotal = 0;
            }

            if (jugador.misMuertos.Count > 0) usarRevivir = 0;

            if (accion == "2" && (usarRevivir == 0 || usarSuperPocion == 0 || usarCuraTotal == 0))
            {
                Console.WriteLine("No puedes usar un ítem. Elige otra acción.");
                facade.ElegirAccion();
                accion = Console.ReadLine();
            }

            Turno.HacerAccion(jugador, accion, oponente, usarRevivir, usarSuperPocion, usarCuraTotal, facade);

            if (oponente.miCatalogo.Count == 0 && !oponente.misItems.OfType<Revivir>().Any())
            {
                EnBatalla = false;
            }
        }
    }
}