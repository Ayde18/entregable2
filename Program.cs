using System;

interface IPokemon
{
    int Atacar();
    double Defender();
}

abstract class PokemonBase : IPokemon
{
    private string nombre;
    private string tipo;
    private int[] ataques; // Tres ataques
    private int defensa;

    public PokemonBase(string nombre, string tipo, int[] ataques, int defensa)
    {
        this.nombre = nombre;
        this.tipo = tipo;
        this.ataques = ataques;
        this.defensa = defensa;
    }

    public int Atacar()
    {
        Random rnd = new Random();
        int ataqueSeleccionado = rnd.Next(0, 3); // Selecciona uno de los tres ataques
        return ataques[ataqueSeleccionado] * rnd.Next(0, 2); // Multiplica por 0 o 1
    }

    public double Defender()
    {
        Random rnd = new Random();
        return defensa * (rnd.Next(0, 2) == 0 ? 1 : 0.5); // Multiplica por 1 o 0.5
    }

    public string Nombre => nombre;
}

class Pokemon : PokemonBase
{
    public Pokemon(string nombre, string tipo, int[] ataques, int defensa)
        : base(nombre, tipo, ataques, defensa)
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Crear Pokémon
        Pokemon p1 = new Pokemon("Pikachu", "Eléctrico", new int[] { 20, 30, 15 }, 20);
        Pokemon p2 = new Pokemon("Charmander", "Fuego", new int[] { 25, 35, 10 }, 25);

        int puntosP1 = 0;
        int puntosP2 = 0;

        for (int i = 0; i < 3; i++)
        {
            // Pokémon 1 ataca y defiende
            puntosP1 += p1.Atacar();
            puntosP1 -= (int)p1.Defender();

            // Pokémon 2 ataca y defiende
            puntosP2 += p2.Atacar();
            puntosP2 -= (int)p2.Defender();
        }

        // Resultados
        if (puntosP1 > puntosP2)
            Console.WriteLine("¡Pokémon 1 gana!");
        else if (puntosP1 < puntosP2)
            Console.WriteLine("¡Pokémon 2 gana!");
        else
            Console.WriteLine("¡Es un empate!");
    }
}
