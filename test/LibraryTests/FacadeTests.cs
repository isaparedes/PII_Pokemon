using NUnit.Framework;
namespace Library.Tests
{
    /// <summary>
    /// Esta es la clase FacadeTests. Se encarga de comprobar que las funciones de facade fluyan correctamente.
    /// </summary>
    [TestFixture]
    public class FacadeTests
    {
        private Facade facade;
        private Entrenador jugador1;
        private Entrenador jugador2;

        [SetUp]
        public void Setup()
        {
            jugador1 = new Entrenador("Jugador 1");
            jugador2 = new Entrenador("Jugador 2");
            facade = new Facade("Jugador 1", "Jugador 2");

            // Simular Pokémon en el Pokedex
            Pokedex.listaPokemons = new List<Pokemon>
            {
                new Pokemon("Pikachu", new Electrico()),
                new Pokemon("Charmander", new Fuego()),
                new Pokemon("Bulbasaur", new Planta()),
                new Pokemon("Squirtle", new Agua()),
                new Pokemon("Jigglypuff", new Normal()),
                new Pokemon("Meowth", new Normal()),
                new Pokemon("Pidgey", new Normal()),
                new Pokemon("Rattata", new Normal())
            };
        }

        /*[Test]
        public void TestComenzarBatalla_SeleccionaPokemon()
        {
            
            // Simular la selección de Pokémon
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("1\n2\n3\n4\n5\n6")); // Seleccionar 6 Pokémon
                facade.ComenzarBatalla();

                // Verificar que ambos jugadores tengan Pokémon seleccionados
                Assert.That(jugador1.miCatalogo.Count == 6);
                Assert.That(jugador2.miCatalogo.Count == 6);
            }
        }

        [Test]
        public void TestRealizarAccion_Atacar()
        {
            // Simular la selección de Pokémon
            jugador1.AgregarPokemon(Pokedex.listaPokemons[0]); // Pikachu
            jugador2.AgregarPokemon(Pokedex.listaPokemons[1]); // Charmander

            jugador1.PokemonActual = jugador1.miCatalogo[0];
            jugador2.PokemonActual = jugador2.miCatalogo[0];

            // Simular un ataque
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("0")); // Atacar
                facade.RealizarAccion(jugador1, jugador2);

                // Verificar que el Pokémon del oponente haya recibido daño
                Assert.That(jugador2.PokemonActual.VidaTotal < 80, Is.True); // Suponiendo que la vida inicial es 80
            }
        }

        [Test]
        public void TestRealizarAccion_CambiarPokemon()
        {
            // Simular la selección de Pokémon
            jugador1.AgregarPokemon(Pokedex.listaPokemons[0]); // Pikachu
            jugador1.AgregarPokemon(Pokedex.listaPokemons[1]); // Charmander
            jugador1.PokemonActual = jugador1.miCatalogo[0];

            // Simular un cambio de Pokémon
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("1\n1")); // Cambiar a Charmander
                facade.RealizarAccion(jugador1, jugador2);

                // Verificar que el Pokémon actual sea Charmander
                Assert.That(jugador1.PokemonActual.Nombre, Is.EqualTo("Charmander"));
            }
        }

        [Test]
        public void TestRealizarAccion_UsarItem()
        {
            // Simular la selección de Pokémon
            jugador1.AgregarPokemon(Pokedex.listaPokemons[0]); // Pikachu
            jugador1.AgregarItem(new SuperPocion());
            jugador1.PokemonActual = jugador1.miCatalogo[0];

            // Simular daño al Pokémon
            jugador1.PokemonActual.RecibirDano(30); // Suponiendo que la vida inicial es 80

            // Usar ítem
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("2\n0")); // Usar Super Poción
                facade.RealizarAccion(jugador1, jugador2);

                // Verificar que la vida del Pokémon se haya restaurado
                Assert.That(jugador1.PokemonActual.VidaTotal == 80); // Debería restaurar a 80
            }
        }

        [Test]
        public void TestMostrarDatosJugador()
        {
            // Simular la selección de Pokémon
            jugador1.AgregarPokemon(Pokedex.listaPokemons[0]); // Pikachu
            jugador1.PokemonActual = jugador1.miCatalogo[0];

            // Capturar la salida de la consola
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                facade.ImprimirDatos(jugador1);

                // Verificar que los datos del jugador se impriman correctamente
                string output = sw.ToString();
                Assert.That(output.Contains("Datos de Jugador 1:"), Is.True);
                Assert.That(output.Contains("Pokémon seleccionados:"), Is.True);
                Assert.That(output.Contains("Pikachu"), Is.True);
            }
        }

        [Test]
        public void TestElegirAccion_AccionNoValida()
        {
            // Simular la selección de Pokémon
            jugador1.AgregarPokemon(Pokedex.listaPokemons[0]); // Pikachu
            jugador1.PokemonActual = jugador1.miCatalogo[0];

            // Simular una acción no válida
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("5")); // Acción no válida
                facade.RealizarAccion(jugador1, jugador2);

                // Verificar que se imprima el mensaje de acción no válida
                string output = sw.ToString();
                Assert.That(output.Contains("Acción no válida. Intenta de nuevo."), Is.True);
            }
        }
*/
        [Test]
        public void TestElegirPokemon_SeleccionarPokemon()
        {
            // Simular la selección de Pokémon
            jugador1.AgregarPokemon(Pokedex.listaPokemons[0]); // Pikachu
            jugador1.AgregarPokemon(Pokedex.listaPokemons[1]); // Charmander
            jugador1.PokemonActual = jugador1.miCatalogo[0];

            // Capturar la salida de la consola
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Facade.ElegirPokemon(jugador1);

                // Verificar que se impriman los Pokémon disponibles
                string output = sw.ToString();
                Assert.That(output.Contains("LISTA DE POKEMONES DISPONIBLES"), Is.True);
                Assert.That(output.Contains("Pikachu"), Is.True);
                Assert.That(output.Contains("Charmander"), Is.True);
            }
        }

        /*[Test]
        public void TestElegirItem_SeleccionarItem()
        {
            // Simular la selección de ítems
            jugador1.AgregarItem(new SuperPocion());
            jugador1.AgregarItem(new Revivir());

            // Capturar la salida de la consola
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Facade.ElegirItem(jugador1);

                // Verificar que se impriman los ítems disponibles
                string output = sw.ToString();
                Assert.That(output.Contains("LISTA DE ÍTEMS DISPONIBLES"), Is.True);
                Assert.That(output.Contains("Super Poción"), Is.True);
                Assert.That(output.Contains("Revivir"),Is.True);
            }
        }
*/
        [Test]
        public void TestElegirAtaque_SeleccionarAtaque()
        {
            // Simular la selección de Pokémon y ataques
            jugador1.AgregarPokemon(Pokedex.listaPokemons[0]); // Pikachu
            jugador1.PokemonActual = jugador1.miCatalogo[0];

            // Capturar la salida de la consola
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Facade.ElegirAtaque(jugador1.PokemonActual);

                // Verificar que se impriman los ataques disponibles
                string output = sw.ToString();
                Assert.That(output.Contains("LISTA DE ATAQUES DISPONIBLES DE Pikachu"));
            }
        }

        [Test]
        public void TestElegirPokemonMuerto_SeleccionarPokemonMuerto()
        {
            // Simular la selección de Pokémon
            jugador1.AgregarPokemon(Pokedex.listaPokemons[0]); // Pikachu
            jugador1.AgregarMuerto(jugador1.miCatalogo[0]); // Agregar Pikachu a muertos

            // Capturar la salida de la consola
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Facade.ElegirPokemonMuerto(jugador1);

                // Verificar que se impriman los Pokémon muertos
                string output = sw.ToString();
                Assert.That(output.Contains("LISTA DE POKEMONES MUERTOS DISPONIBLES"), Is.True);
                Assert.That(output.Contains("Pikachu"), Is.True);
            }
        }

        [Test]
        public void TestElegirPokemonHerido_SeleccionarPokemonHerido()
        {
            // Simular la selección de Pokémon
            jugador1.AgregarPokemon(Pokedex.listaPokemons[0]); 
            // Pikachu
            jugador1.PokemonActual = jugador1.miCatalogo[0];
            jugador1.PokemonActual.RecibirDano(30); // Simular daño

            // Capturar la salida de la consola
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Facade.ElegirPokemonHerido(jugador1, 0); // Usar Super Poción

                // Verificar que se impriman los Pokémon heridos
                string output = sw.ToString();
                Assert.That(output.Contains("LISTA DE POKEMONES HERIDOS DISPONIBLES"), Is.True);
                Assert.That(output.Contains("Pikachu"), Is.True);
            }
        }

        [Test]
        public void TestElegirAtaqueSimple_SeleccionarAtaqueSimple()
        {
            // Simular la selección de Pokémon
            jugador1.AgregarPokemon(Pokedex.listaPokemons[0]); // Pikachu
            jugador1.PokemonActual = jugador1.miCatalogo[0];

            // Capturar la salida de la consola
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Facade.ElegirAtaqueSimple(jugador1.PokemonActual);

                // Verificar que se impriman los ataques simples disponibles
                string output = sw.ToString();
                Assert.That(output.Contains("LISTA DE ATAQUES SIMPLES DISPONIBLES DE Pikachu"), Is.True);
            }
        } 
    } }
        /*[Test]
        public void TestElegirAccion_AtacarConPokemonDormido()
        {
            // Simular la selección de Pokémon
            jugador1.AgregarPokemon(Pokedex.listaPokemons[0]); // Pikachu
            jugador1.PokemonActual = jugador1.miCatalogo[0];
            jugador1.PokemonActual.Dormido = true; // Hacer que Pikachu esté dormido

            // Simular un ataque
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("0")); // Intentar atacar
                facade.RealizarAccion(jugador1, jugador2);

                // Verificar que se imprima el mensaje de que no se puede atacar
                string output = sw.ToString();
                Assert.That(output.Contains("No se puede elegir atacar, su pokemon está dormido."), Is.True);
            }
        }

        [Test]
        public void TestElegirAccion_AtacarConPokemonParalizado()
        {
            // Simular la selección de Pokémon
            jugador1.AgregarPokemon(Pokedex.listaPokemons[0]); // Pikachu
            jugador1.PokemonActual = jugador1.miCatalogo[0];
            jugador1.PokemonActual.Paralizado = true; // Hacer que Pikachu esté paralizado

            // Simular un ataque
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("0")); // Intentar atacar
                facade.RealizarAccion(jugador1, jugador2);

                // Verificar que se imprima el mensaje de que no se puede atacar
                string output = sw.ToString();
                Assert.That(output.Contains("No se puede elegir atacar, su pokemon esta paralizado."), Is.True);
            }
        }

        [Test]
        public void TestElegirAccion_UsarItemSinPokemonHerido()
        {
            // Simular la selección de Pokémon
            jugador1.AgregarPokemon(Pokedex.listaPokemons[0]); // Pikachu
            jugador1.PokemonActual = jugador1.miCatalogo[0];
            jugador1.AgregarItem(new SuperPocion()); // Agregar Super Poción

            // Simular que no hay Pokémon heridos
            jugador1.PokemonActual.Curar(80); // Curar completamente

            // Simular usar un ítem
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("2\n0")); // Intentar usar Super Poción
                facade.RealizarAccion(jugador1, jugador2);

                // Verificar que se imprima el mensaje de que no se puede usar el ítem
                string output = sw.ToString();
                Assert.That(output.Contains("No puedes usar un ítem. Elige otra acción."), Is.True);
            }
        }
    }
}*/