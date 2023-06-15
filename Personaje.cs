namespace EspacioPersonaje;


public class Personaje{
    private tipos tipo;
    private string nombres;
    private string nombre;
    private string apodo;
    private DateTime fechaNacimiento;
    private int edad;
    private int velocidad;
    private int destreza;
    private int fuerza;
    private int nivel;
    private int armadura;
    private int salud;
    public tipos Tipo { get => tipo; set => tipo; }
    public string Nombre { get => nombre; set => nombre; }
    public string Apodo { get => apodo; set => apodo; }
    public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento; }
    public int Edad { get => edad; set => edad; }
    public int Velocidad { get => velocidad; set => velocidad; }
    public int Destreza { get => destreza; set => destreza; }
    public int Fuerza { get => fuerza; set => fuerza; }
    public int Nivel { get => nivel; set => nivel; }
    public int Armadura { get => armadura; set => armadura; }
    public int Salud { get => salud; set => salud; }

}