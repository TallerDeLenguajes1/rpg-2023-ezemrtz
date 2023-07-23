namespace EspacioPersonaje;

public class FabricaPersonajes{
    private static string[] nombres = {"Pepe", "Pedro", "Juan", "Mario", "Josesito"};
    private static string[] apodos = {"The Killer", "El golpeador", "El saltarin", "El payaso", "El molesto"};
    public Personaje CrearPersonaje(){
        var rd = new Random();
        Personaje personaje = new Personaje();
        var values = Enum.GetValues(typeof(tipos));
        personaje.Tipo = (tipos)values.GetValue(rd.Next(values.Length));
        personaje.Nombre = nombres[rd.Next(0, nombres.Length)];
        personaje.Apodo = apodos[rd.Next(0, apodos.Length)];
        personaje.FechaNacimiento= new DateTime(rd.Next(1723,2024), rd.Next(1,13), rd.Next(1,32));
        personaje.Edad = DateTime.Today.AddTicks(-personaje.FechaNacimiento.Ticks).Year-1;
        personaje.Velocidad = rd.Next(1,10);
        personaje.Destreza = rd.Next(1,5);
        personaje.Fuerza = rd.Next(1,10);
        personaje.Nivel = rd.Next(1,10);
        personaje.Armadura = rd.Next(1,10);
        personaje.Salud = 100;
        return personaje;
    }
}