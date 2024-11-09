using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(Batalla))]
public class BatallaTests
{
    private Entrenador jugador1;
    private Entrenador jugador2;
    private Batalla batalla;
    private Facade facade;
    
    [SetUp]
    public void SetUp()
    {
        jugador1 = new Entrenador("Jugador1");
        jugador2 = new Entrenador("Jugador2");
        batalla = new Batalla(jugador1, jugador2,facade);
    }

    [Test]
    public void TestCrearBatalla()
    {
        bool esperado = true;
        Entrenador esperado1 = jugador1;
        Entrenador esperado2 = jugador2;
        int esperado3 = 7;
        Assert.That(esperado,Is.EqualTo(Batalla.EnBatalla));
        Assert.That(esperado1,Is.EqualTo(batalla.Jugador1));
        Assert.That(esperado2,Is.EqualTo(batalla.Jugador2));
        Assert.That(esperado3,Is.EqualTo(jugador1.misItems.Count));
        Assert.That(esperado3,Is.EqualTo(jugador2.misItems.Count));
    }
}