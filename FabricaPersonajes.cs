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
        personaje.FechaNacimiento= new DateTime(rd.Next(1723,2023), rd.Next(1,13), rd.Next(1,31));
        personaje.Edad = DateTime.Today.AddTicks(-personaje.FechaNacimiento.Ticks).Year-1;
        personaje.Velocidad = rd.Next(1,11);
        personaje.Destreza = rd.Next(1,6);
        personaje.Fuerza = rd.Next(3,11);
        personaje.Armadura = rd.Next(1,11);
        switch(personaje.Tipo){
            case tipos.Luchador: 
                personaje.Fuerza += 3;
            break;
            case tipos.Ninja:
                personaje.Destreza += 3;
            break;
            case tipos.Tanque:
                personaje.Armadura += 3;
            break;
            case tipos.Mago:
                personaje.Velocidad += 3;
            break;
            default: break;
        }
        personaje.Nivel = rd.Next(1,11);
        personaje.Salud = 100;
        return personaje;
    }
}