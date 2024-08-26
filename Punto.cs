using System;
using System.Collections.Generic;

interface IEquipo
{
    void AgregarJugador(Jugador jugador);
    int ObtenerPuntuacionTotal();
}

class Jugador
{
    private string nombre;
    private string posicion;
    private int rendimiento;

    public Jugador(string nombre, string posicion, int rendimiento)
    {
        this.nombre = nombre;
        this.posicion = posicion;
        this.rendimiento = rendimiento;
    }

    public string Nombre => nombre;
    public int Rendimiento => rendimiento;
}

class Equipo : IEquipo
{
    private List<Jugador> jugadores = new List<Jugador>();

    public void AgregarJugador(Jugador jugador)
    {
        if (jugadores.Count < 3) // Cada equipo tiene hasta 3 jugadores
        {
            jugadores.Add(jugador);
        }
        else
        {
            Console.WriteLine("El equipo ya tiene 3 jugadores.");
        }
    }

    public int ObtenerPuntuacionTotal()
    {
        int puntuacion = 0;
        foreach (var jugador in jugadores)
        {
            puntuacion += jugador.Rendimiento;
        }
        return puntuacion;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Lista de jugadores registrados
        List<Jugador> jugadoresRegistrados = new List<Jugador>
        {
            new Jugador("Alice", "Alero", 5),
            new Jugador("Bob", "Base", 7),
            new Jugador("Charlie", "Escolta", 14),
            new Jugador("David", "Ala-Pívot", 6),
            new Jugador("Eva", "Pívot", 7),
            new Jugador("Frank", "Alero", 20)
        };

        // Crear equipos
        Equipo equipo1 = new Equipo();
        Equipo equipo2 = new Equipo();
        Random rnd = new Random();

        // Seleccionar jugadores aleatorios
        while (equipo1.ObtenerPuntuacionTotal() < 3 && jugadoresRegistrados.Count > 0)
        {
            Jugador jugador = jugadoresRegistrados[rnd.Next(jugadoresRegistrados.Count)];
            equipo1.AgregarJugador(jugador);
            jugadoresRegistrados.Remove(jugador);
        }

        while (equipo2.ObtenerPuntuacionTotal() < 3 && jugadoresRegistrados.Count > 0)
        {
            Jugador jugador = jugadoresRegistrados[rnd.Next(jugadoresRegistrados.Count)];
            equipo2.AgregarJugador(jugador);
            jugadoresRegistrados.Remove(jugador);
        }

        // Comparar puntuaciones
        int puntuacionEquipo1 = equipo1.ObtenerPuntuacionTotal();
        int puntuacionEquipo2 = equipo2.ObtenerPuntuacionTotal();

        Console.WriteLine("Puntuación del equipo 1: " + puntuacionEquipo1);
        Console.WriteLine("Puntuación del equipo 2: " + puntuacionEquipo2);

        if (puntuacionEquipo1 > puntuacionEquipo2)
            Console.WriteLine("¡El equipo 1 gana!");
        else if (puntuacionEquipo1 < puntuacionEquipo2)
            Console.WriteLine("¡El equipo 2 gana!");
        else
            Console.WriteLine("¡Es un empate!");
    }
}
