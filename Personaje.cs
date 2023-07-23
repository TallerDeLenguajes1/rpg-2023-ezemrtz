namespace EspacioPersonaje;


public class Personaje{
    private tipos tipo;
    private string nombre;
    private string apodo;
    private DateTime fechaNacimiento;
    private double edad;
    private double velocidad;
    private double destreza;
    private double fuerza;
    private double nivel;
    private double armadura;
    private double salud;
    public tipos Tipo { get => tipo; set => tipo = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Apodo { get => apodo; set => apodo = value; }
    public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
    public double Edad { get => edad; set => edad = value; }
    public double Velocidad { get => velocidad; set => velocidad = value; }
    public double Destreza { get => destreza; set => destreza = value; }
    public double Fuerza { get => fuerza; set => fuerza = value; }
    public double Nivel { get => nivel; set => nivel = value; }
    public double Armadura { get => armadura; set => armadura = value; }
    public double Salud { get => salud; set => salud = value; }

    public void MostrarInfo(){
        Console.WriteLine("=================================");
        Console.WriteLine("Tipo: {0}", this.tipo);
        Console.WriteLine("Nombre: {0}", this.nombre);
        Console.WriteLine("Apodo: {0}", this.apodo);
        //Console.WriteLine("Fecha Nacimiento: {0}", this.fechaNacimiento.ToShortDateString());
        Console.WriteLine("Edad: {0}", this.edad);
        Console.WriteLine("----------------");
        Console.WriteLine("Nivel: {0}", this.nivel);
        Console.WriteLine("Velocidad: {0}", this.velocidad);
        Console.WriteLine("Destreza: {0}", this.destreza);
        Console.WriteLine("Armadura: {0}", this.armadura);
        Console.WriteLine("Salud: {0}", this.salud);
        Console.WriteLine("=================================");
    }

    public double Atacar(Personaje Defensor){
        Random rd = new Random();
        double DañoProvocado;
        double Ataque = destreza*fuerza*nivel;
        double Efectividad = rd.Next(1,101);
        double Defensa = Defensor.Armadura*Defensor.Velocidad;
        DañoProvocado = (Ataque*Efectividad - Defensa)/500;
        return DañoProvocado;
    }

    public void SubirNivel(){
        this.nivel++;
        this.velocidad++;
        this.destreza++;
        this.fuerza++;
        this.armadura++;
        this.salud = 100;
    }
}

