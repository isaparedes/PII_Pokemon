using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(Entrenador))]
public class EntrenadorTests
{
    private Entrenador entrenador;
    private Pokemon pokemon;
    
    [SetUp]
    public void SetUp()
    {
        entrenador = new Entrenador("Entrenador");
        pokemon = new Pokemon("Pikachu", new Electrico());
    }

    [Test]
    public void TestCrearEntrenador()
    {
        string esperado = "Entrenador";
        Assert.That(esperado, Is.EqualTo(entrenador.Nombre));
    }
}