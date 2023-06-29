using EspacioPersonaje;

internal class Program
{
    private static void Main(string[] args)
    {
        PersonajesJson HelperPersonajesJson = new PersonajesJson();
        FabricaPersonajes Fabrica = new FabricaPersonajes();

        string NombreArchivoPersonajes = "personajes.json";
        List<Personaje> ListaPersonajes;
        if (HelperPersonajesJson.Existe(NombreArchivoPersonajes))
        {
            ListaPersonajes = HelperPersonajesJson.LeerPersonajes(NombreArchivoPersonajes);
        }
        else
        {
            ListaPersonajes = new List<Personaje>();
            for (int i = 0; i < 10; i++)
            {
                Personaje personaje = Fabrica.CrearPersonaje();
                ListaPersonajes.Add(personaje);
            }
            HelperPersonajesJson.GuardarPersonajes(ListaPersonajes);
        }
        for (int i = 0; i < 10; i++)
        {
            ListaPersonajes[i].MostrarInfo();
        }
    }
}