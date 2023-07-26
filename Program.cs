using EspacioPersonaje;


Random random = new Random();
PersonajesJson HelperPersonajesJson = new PersonajesJson();
FabricaPersonajes Fabrica = new FabricaPersonajes();
ConsultaAPI HelperAPI = new ConsultaAPI();
Gameplay HelperGameplay = new Gameplay();
Mensajes Msj = new Mensajes();


string NombreArchivoPersonajes = "personajes.json";
List<Personaje> ListaPersonajes;

List<string> ListaNombres = HelperAPI.ObtenerNombres(); // CREO LISTA DE NOMBRES UTILIZANDO LA API

//CONTROLO Y CREO EL ARCHIVO JSON CON LOS PERSONAJES SI NO EXISTE
if (HelperPersonajesJson.Existe(NombreArchivoPersonajes)){
    ListaPersonajes = HelperPersonajesJson.LeerPersonajes(NombreArchivoPersonajes);
}else{
    ListaPersonajes = new List<Personaje>();
    for (int i = 0; i < 10; i++)
    {
        Personaje personaje = Fabrica.CrearPersonaje(ListaNombres);
        ListaPersonajes.Add(personaje);
    }
    HelperPersonajesJson.GuardarPersonajes(ListaPersonajes);
} 

//EMPIEZA EL MINIJUEGO
Msj.Portada();
HelperGameplay.Avanzar();

HelperGameplay.MostrarListaPersonajes(ListaPersonajes);
Thread.Sleep(300);
HelperGameplay.Avanzar();
Console.Clear();

Personaje Personaje1, Personaje2, Ganador=null;
(Personaje1, Personaje2) = HelperGameplay.DefinirPeleadores(ListaPersonajes);

while(ListaPersonajes.Count > 1) // COMIENZAN LAS PELEAS
{
    Console.Clear();
    Msj.Encuentro(Personaje1, Personaje2);
    Msj.MostrarPeleadores(Personaje1, Personaje2);

    Console.WriteLine("[-----------[  COMIENZA LA PELEA  ]-----------]");
    Thread.Sleep(200);
    while (Personaje1.Salud > 0 & Personaje2.Salud > 0)
    {   
        Msj.MostrarSalud(Personaje1);
        Msj.MostrarSalud(Personaje2);
        Console.WriteLine();
        Thread.Sleep(450);

        Console.WriteLine(" ======= Turno: Peleador 1 =======");
        HelperGameplay.Ataque(Personaje1, Personaje2);
        Thread.Sleep(200);
        
        if(Personaje2.Salud <= 0)
        {
            Console.WriteLine("\n═════════════════════════════════\n");
            break;
        }

        Console.WriteLine("\n ======= Turno: Peleador 2 =======");
        HelperGameplay.Ataque(Personaje2, Personaje1);    
        Thread.Sleep(200);

        Console.WriteLine("\n═════════════════════════════════\n");
        Thread.Sleep(200);
    }

    Ganador = HelperGameplay.DefinirGanador(ListaPersonajes, Personaje1, Personaje2);

    // CONTROLO SI QUEDA UN UNICO PELEADOR PARA TERMINAR EL JUEGO
    if(ListaPersonajes.Count > 1){
        (Personaje1, Personaje2) = HelperGameplay.DefinirPeleadores(ListaPersonajes);
    }

    
    Msj.GanadorPelea(Ganador);
    Ganador.SubirNivel();
    Thread.Sleep(2000);
    HelperGameplay.Avanzar();
}

// MUESTRO AL CAMPEON
Console.Clear();
Msj.CampeonMinijuego(Ganador);

// FIN DEL MINIJUEGO