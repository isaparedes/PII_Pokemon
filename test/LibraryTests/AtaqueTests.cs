using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(Library.Ataque))]
public class AtaqueTests
{
    private Ataque ataque;
    
    [SetUp]
    public void SetUp()
    {
        ataque = new Ataque("Ataque",10,80,"Fuego");
    }

    [Test]
    public void TestCrearAtaque()
    {
        string esperado = "Ataque";
        int esperado1 = 10;
        int esperado2 = 80;
        string esperado3 = "Fuego";
        Assert.That(esperado,Is.EqualTo(ataque.Nombre));
        Assert.That(esperado1,Is.EqualTo(ataque.Dano));
        Assert.That(esperado2,Is.EqualTo(ataque.Precision));
        Assert.That(esperado3,Is.EqualTo(ataque.Tipo));
    }
    
}