namespace EspacioPersonaje;

public class FabricaPersonajes{
    private static string[] nombres = {"Pepe", "Pedro"};
    private static string[] apodos = {"Pep", "Pedrito"};
    public Personaje CrearPersonaje(){
        var rd = new Random();
        Personaje personaje = new Personaje;
        int indice = rd.Next(0,tipos.Count());
        personaje.Tipo = tipos.ElementAt(indice);
        personaje.Nombre = nombres[rd.Next(0, nombres.Length)];
        personaje.Apodo = apodos[rd.Next(0, apodos.Length)];
        personaje.Edad = rd.Next(1,300);
        personaje.Velocidad = rd.Next(1,10);
        personaje.Destreza = rd.Next(1,10);
        personaje.Fuerza = rd.Next(1,10);
        personaje.Nivel = rd.Next(1,10);
        personaje.Armadura = rd.Next(1,10);
        personaje.Salud = 100;
        return personaje;
    }
}