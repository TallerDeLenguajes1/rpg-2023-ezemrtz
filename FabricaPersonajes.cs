namespace EspacioPersonaje;

public class FabricaPersonajes{
    private static string[] apodos = {"The Killer", "El golpeador", "El saltarin", "El payaso", "El molesto", "Fortachon", "Velocista", "Escurridizo"};
    public Personaje CrearPersonaje(List<string> ListaNombres){
        var rd = new Random();
        ConsultaAPI HelperAPI = new ConsultaAPI();
        Personaje personaje = new Personaje();
        var values = Enum.GetValues(typeof(tipos));
        personaje.Tipo = (tipos)values.GetValue(rd.Next(values.Length));
        string name = ListaNombres[rd.Next(0, ListaNombres.Count)];
        ListaNombres.Remove(name);
        personaje.Nombre = name;
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