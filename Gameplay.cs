namespace EspacioPersonaje;
public class Gameplay{

    public void Ataque(Personaje Atacante, Personaje Defensor){
        double Daño = Atacante.Atacar(Defensor);
        Defensor.Salud -= Daño;
        Console.WriteLine("Daño infligido: {0}", Daño);
    }

    public void Avanzar(){
        ConsoleKeyInfo cc;
        do
        {
            Console.WriteLine("\nPresiona <ENTER> para continuar...\n");
            cc = Console.ReadKey();
        } while (cc.Key != ConsoleKey.Enter);
    }

    public (Personaje, Personaje) DefinirPeleadores(List<Personaje> ListaPersonajes){
        Random random = new Random();
        Personaje Peleador1, Peleador2;
        Peleador1 = ListaPersonajes[random.Next(0,ListaPersonajes.Count)];
        do{
            Peleador2 = ListaPersonajes[random.Next(0,ListaPersonajes.Count)];
        }while(Peleador1 == Peleador2);
        return (Peleador1, Peleador2);
    }

    public Personaje DefinirGanador(List<Personaje> ListaPersonajes, Personaje Peleador1, Personaje Peleador2){
        Personaje Ganador;
        if(Peleador1.Salud <= 0){
            ListaPersonajes.Remove(Peleador1);
            Ganador = Peleador2;
        }else{
            ListaPersonajes.Remove(Peleador2);
            Ganador = Peleador1;
        }
        return Ganador;
    }

    public void MostrarListaPersonajes(List<Personaje> ListaPersonajes){
        Console.WriteLine("-------------- Los prisioneros que participaran son los siguientes --------------");
        Thread.Sleep(1000);
        for (int i = 0; i < ListaPersonajes.Count; i++)
        {
            ListaPersonajes[i].MostrarInfo();
            Thread.Sleep(100);
        }
    }
}