namespace Library;

public class Entrenador
{
    public string Nombre { get; private set; }
    public List<Pokemon> miCatalogo = new List<Pokemon>();
    public List<Pokemon> misMuertos = new List<Pokemon>();
    public List<Item> misItems = new List<Item>();
    public bool MiTurno { get; set; }
    public int Turnos { get; set; }
    
    public void AgregarPokemon(string nombre)
    {
        if (this.miCatalogo.Count > 0)
        {
            bool encontrado = false;
            for (int i = 0; i < this.miCatalogo.Count; i++)
            {
                Pokemon pokemon = this.miCatalogo[i];
                if (pokemon.Nombre == nombre)
                {
                    encontrado = true;
                }
            }
            if (encontrado == false && miCatalogo.Count <= 6 && Batalla.EnBatalla == false)
            {
                Pokemon pokemonNuevo = Pokedex.BuscarPokemon(nombre);
                miCatalogo.Add(pokemonNuevo);
            }
        }
        else
        {
            
            Pokemon pokemonNuevo = Pokedex.BuscarPokemon(nombre);
            miCatalogo.Add(pokemonNuevo);
        }
       
        
    }
    public void QuitarPokemon(Pokemon pokemon)
    {
        if (this.miCatalogo.Contains(pokemon))
        {
            this.miCatalogo.Remove(pokemon);
        }
    }

    public void AgregarItem(Item item)
    {
        if (Batalla.EnBatalla)
        {
            this.misItems.Add(item);
        }
    }
    
    public void QuitarItem(Item item)
    {
        if (this.misItems.Contains(item))
        {
            this.misItems.Remove(item);
        }
    }

    public void AgregarMuerto(Pokemon pokemon)
    {
        if (!this.misMuertos.Contains(pokemon))
        {
            this.misMuertos.Add(pokemon);
        }
    }
    
    public void QuitarMuerto(Pokemon pokemon)
    {
        if (this.miCatalogo.Contains(pokemon))
        {
            this.miCatalogo.Remove(pokemon);
        }
    }

    public void Recuperar(Pokemon pokemon)
    {
     
        this.miCatalogo.Add(pokemon);
        
    }
    public Pokemon PokemonActual { get; set; }
    public Entrenador(string nombre)
    {
        this.Nombre = nombre;
    }
}