namespace EspacioPersonaje;

public class Mensajes{
    public void Portada(){
        Console.WriteLine(@"
        ╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗

         ██╗     ██╗██████╗ ███████╗██████╗ ████████╗ █████╗ ██████╗     ███╗   ███╗ ██████╗ ██████╗ ████████╗ █████╗ ██╗     
         ██║     ██║██╔══██╗██╔════╝██╔══██╗╚══██╔══╝██╔══██╗██╔══██╗    ████╗ ████║██╔═══██╗██╔══██╗╚══██╔══╝██╔══██╗██║     
         ██║     ██║██████╔╝█████╗  ██████╔╝   ██║   ███████║██║  ██║    ██╔████╔██║██║   ██║██████╔╝   ██║   ███████║██║     
         ██║     ██║██╔══██╗██╔══╝  ██╔══██╗   ██║   ██╔══██║██║  ██║    ██║╚██╔╝██║██║   ██║██╔══██╗   ██║   ██╔══██║██║     
         ███████╗██║██████╔╝███████╗██║  ██║   ██║   ██║  ██║██████╔╝    ██║ ╚═╝ ██║╚██████╔╝██║  ██║   ██║   ██║  ██║███████╗
         ╚══════╝╚═╝╚═════╝ ╚══════╝╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝╚═════╝     ╚═╝     ╚═╝ ╚═════╝ ╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝╚══════╝
                        10 PRISIONEROS SE ENFRENTAN EN UN CAMPO DE BATALLA PARA CONSEGUIR LA LIBERTAD
                                                    SOLO UNO QUEDA EN PIE
        ╚═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
    }

    public void Encuentro(Personaje Personaje1, Personaje Personaje2){
        Random rd = new Random();
        string[] frases = {Personaje1.Nombre+ " '" + Personaje1.Apodo + "'" + " se ha encontrado con " + Personaje2.Nombre + " '" + Personaje2.Apodo + "'", 
                           Personaje1.Nombre+ " '" + Personaje1.Apodo + "'" + " observa a " + Personaje2.Nombre + " '" + Personaje2.Apodo + "'" + " desde lejos y decide atacar",
                           Personaje1.Nombre+ " '" + Personaje1.Apodo + "'" + " deja el miedo atras y decide enfrentarse a " + Personaje2.Nombre + " '" + Personaje2.Apodo + "'",};
        string fraseObtenida = "¡" + frases[rd.Next(0,3)] + "!";
        foreach (var item in fraseObtenida)
        {
            Console.Write(item);
            Thread.Sleep(10);
        }
        Console.WriteLine();
        Thread.Sleep(100);
    }

    public void MostrarPeleadores(Personaje Personaje1, Personaje Personaje2){
        Console.WriteLine("╔═══════════ PELEADORES ═══════════╗");
        Console.WriteLine("        --- Peleador 1 ---");
        Console.WriteLine("        {0} '{1}'", Personaje1.Nombre, Personaje1.Apodo);
        Console.WriteLine("        Nivel: {0}", Personaje1.Nivel);
        Console.WriteLine("        --- Peleador 2 ---");
        Console.WriteLine("        {0} '{1}'", Personaje2.Nombre, Personaje2.Apodo);
        Console.WriteLine("        Nivel: {0}", Personaje2.Nivel);
        Console.WriteLine("╚═══════════ ══════════ ═══════════╝");
        Thread.Sleep(4000);
    }

    public void MostrarSalud(Personaje personaje){
        Console.WriteLine("(=== SALUD {0}: {1:0.00} ===)", personaje.Nombre, personaje.Salud);
    }

    public void GanadorPelea(Personaje ganador){
        Console.WriteLine("╔═══════════ ¡¡ GANADOR !! ═══════════╗");
        Console.WriteLine("         {0} '{1}'", ganador.Nombre, ganador.Apodo);
        Console.WriteLine("         Nivel: {0}", ganador.Nivel);
        Console.WriteLine("╚═════════════════════════════════════╝");
    }

    public void InsutoPerdedor(string insulto){
        string frase = "Se escucha al perdedor decir unas ultimas palabras: - ¡" + insulto + "!";
        foreach (var item in frase)
        {
            Console.Write(item);
            Thread.Sleep(10);
        }
        Console.WriteLine();
        Thread.Sleep(150);
    }

    public void CampeonMinijuego(Personaje campeon){
        Console.WriteLine("╔════════════════════ GRAN CAMPEON ═════════════════════╗");
        Console.WriteLine("\n     ¡{0} '{1}' es el ultimo peleador en pie!", campeon.Nombre, campeon.Apodo);
        Console.WriteLine("             SERA RECOMPENSADO CON SU LIBERTAD");
        Console.WriteLine("             ╔════════════════════════╗");
        Console.WriteLine("                 Tipo: {0}", campeon.Tipo);
        Console.WriteLine("                 Nombre: {0}", campeon.Nombre);
        Console.WriteLine("                 Apodo: {0}", campeon.Apodo);
        Console.WriteLine("                 Edad: {0}", campeon.Edad);
        Console.WriteLine("                 ----------------");
        Console.WriteLine("                 Nivel: {0}", campeon.Nivel);
        Console.WriteLine("                 Velocidad: {0}", campeon.Velocidad);
        Console.WriteLine("                 Destreza: {0}", campeon.Destreza);
        Console.WriteLine("                 Fuerza: {0}", campeon.Fuerza);
        Console.WriteLine("                 Armadura: {0}", campeon.Armadura);
        Console.WriteLine("                 Salud: {0}", campeon.Salud);
        Console.WriteLine("             ╚════════════════════════╝");
        Console.WriteLine("\n╚═══════════════════════════════════════════════════════╝");
    }
}