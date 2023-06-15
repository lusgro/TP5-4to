namespace TP5.Models;

public static class Escape
{
    public static string[] incognitasSalas;
    public static int intentos = 1;
    public static int pistasUsadas = 0;
    public static int estadoJuego = 1;

    private static void InicializarJuego()
    {
        incognitasSalas = new string[] {"mmprtv", "140", "cbad", "4"};
    }
    public static int GetEstadoJuego()
    {
        return estadoJuego;
    }
    public static bool ResolverSala(int sala, string incognita)
    {
        if (incognitasSalas == null)
        {
            InicializarJuego();
        }
        if (sala < estadoJuego)
        {
            return false;
        }
        if (incognitasSalas[sala - 1] == incognita)
        {
            estadoJuego++;
            return true;
        }
        else
        {
            return false;
        }
    }
}