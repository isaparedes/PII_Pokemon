namespace Library
{
    public class Batalla
    {
        public static bool EnBatalla;
        public Entrenador Jugador1 { get; private set; }
        public Entrenador Jugador2 { get; private set; }
        private Facade facade;

        public Batalla(Entrenador jugador1, Entrenador jugador2, Facade facade)
        {
            EnBatalla = true;
            this.Jugador1 = jugador1;
            this.Jugador2 = jugador2;
            this.facade = facade;

            InicializarItems(Jugador1);
            InicializarItems(Jugador2);
        }

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

        private void AsignarPokemonInicial(Entrenador jugador)
        {
            Random random = new Random();
            int pokemonRandom = random.Next(0, 6);
            jugador.PokemonActual = jugador.miCatalogo[pokemonRandom];
        }

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

            Turno.HacerAccion(jugador, accion, oponente, usarRevivir, usarSuperPocion, usarCuraTotal);

            if (oponente.miCatalogo.Count == 0 && !oponente.misItems.OfType<Revivir>().Any())
            {
                EnBatalla = false;
            }
        }
    }
}