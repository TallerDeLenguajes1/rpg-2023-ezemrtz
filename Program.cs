using EspacioPersonaje;


Random random = new Random();
PersonajesJson HelperPersonajesJson = new PersonajesJson();
FabricaPersonajes Fabrica = new FabricaPersonajes();
ConsultaAPI HelperAPI = new ConsultaAPI();

string NombreArchivoPersonajes = "personajes.json";
List<Personaje> ListaPersonajes;

if (HelperPersonajesJson.Existe(NombreArchivoPersonajes)){
    ListaPersonajes = HelperPersonajesJson.LeerPersonajes(NombreArchivoPersonajes);
}else{
    ListaPersonajes = new List<Personaje>();
    for (int i = 0; i < 10; i++)
    {
        Personaje personaje = Fabrica.CrearPersonaje();
        ListaPersonajes.Add(personaje);
    }
    HelperPersonajesJson.GuardarPersonajes(ListaPersonajes);
}

for (int i = 0; i < 10; i++){
    ListaPersonajes[i].MostrarInfo();
}
Console.Clear();
Console.WriteLine(@" ██████╗ █████╗ ███╗   ███╗██╗███╗   ██╗ ██████╗      █████╗     ██╗      █████╗      ██████╗██╗███╗   ███╗ █████╗ 
██╔════╝██╔══██╗████╗ ████║██║████╗  ██║██╔═══██╗    ██╔══██╗    ██║     ██╔══██╗    ██╔════╝██║████╗ ████║██╔══██╗
██║     ███████║██╔████╔██║██║██╔██╗ ██║██║   ██║    ███████║    ██║     ███████║    ██║     ██║██╔████╔██║███████║
██║     ██╔══██║██║╚██╔╝██║██║██║╚██╗██║██║   ██║    ██╔══██║    ██║     ██╔══██║    ██║     ██║██║╚██╔╝██║██╔══██║
╚██████╗██║  ██║██║ ╚═╝ ██║██║██║ ╚████║╚██████╔╝    ██║  ██║    ███████╗██║  ██║    ╚██████╗██║██║ ╚═╝ ██║██║  ██║
 ╚═════╝╚═╝  ╚═╝╚═╝     ╚═╝╚═╝╚═╝  ╚═══╝ ╚═════╝     ╚═╝  ╚═╝    ╚══════╝╚═╝  ╚═╝     ╚═════╝╚═╝╚═╝     ╚═╝╚═╝  ╚═╝");
Thread.Sleep(2000);
Personaje Personaje1, Personaje2, Ganador=null;
Personaje1 = ListaPersonajes[random.Next(0,10)];
ListaPersonajes.Remove(Personaje1);
Personaje2 = ListaPersonajes[random.Next(0,9)];
ListaPersonajes.Remove(Personaje2);
double Daño;
string insulto;
while(ListaPersonajes.Count > 0)
{
    Console.WriteLine("======= PELEADORES =======");
    Console.WriteLine("--- Peleador 1 ---");
    Console.WriteLine("{0} '{1}'", Personaje1.Nombre, Personaje1.Apodo);
    Console.WriteLine("Nivel: {0}", Personaje1.Nivel);
    Console.WriteLine("--- Peleador 2 ---");
    Console.WriteLine("{0} '{1}'", Personaje2.Nombre, Personaje2.Apodo);
    Console.WriteLine("Nivel: {0}", Personaje2.Nivel);
    while (Personaje1.Salud > 0 & Personaje2.Salud > 0)
    {   
        Console.WriteLine("======= Salud {0}: {1}", Personaje1.Nombre, Personaje1.Salud);
        Console.WriteLine("======= Salud {0}: {1}", Personaje2.Nombre, Personaje2.Salud);
        Console.WriteLine("======= Turno: Peleador 1 =======");
        Daño = Personaje1.Atacar(Personaje2);
        Personaje2.Salud -= Daño;
        Console.WriteLine("Daño infligido: {0}", Daño);
        if(Personaje2.Salud <= 0){break;}
        Console.WriteLine("======= Turno: Peleador 2 =======");
        Daño = Personaje2.Atacar(Personaje1);
        Personaje1.Salud -= Daño;
        Console.WriteLine("Daño infligido: {0}", Daño);
        //Thread.Sleep(100);
    }

    if(Personaje1.Salud <= 0){
        Ganador = Personaje2;
        if(ListaPersonajes.Count >= 1){
            Personaje1 = ListaPersonajes[random.Next(0,ListaPersonajes.Count)];
            ListaPersonajes.Remove(Personaje1);
        }
    }else{
        Ganador = Personaje1;
        if(ListaPersonajes.Count >= 1){
            Personaje2 = ListaPersonajes[random.Next(0,ListaPersonajes.Count)];
            ListaPersonajes.Remove(Personaje2);
        }
    }
    Ganador.SubirNivel();
    Console.WriteLine("¡{0}!", HelperAPI.ObtenerInsulto());
    Console.WriteLine("========= ¡¡¡ GANADOR !!! =========");
    Console.WriteLine("{0} '{1}'", Ganador.Nombre, Ganador.Apodo);
    Console.WriteLine("Nivel: {0}", Ganador.Nivel);
    
}

Console.WriteLine("========= ¡¡¡ CAMPEON !!! =========");
Console.WriteLine("{0} '{1}'", Ganador.Nombre, Ganador.Apodo);
Console.WriteLine("Nivel: {0}", Ganador.Nivel);

Ganador.MostrarInfo();