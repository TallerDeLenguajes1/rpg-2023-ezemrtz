namespace EspacioPersonaje;
using System.Text.Json;
public class PersonajesJson{
    public void GuardarPersonajes(List<Personaje> listaPersonajes){
        string JsonString = JsonSerializer.Serialize(listaPersonajes);
        using(StreamWriter archivo = new StreamWriter("personajes.json")){;
            archivo.WriteLine(JsonString);
            archivo.Close();
        }
    }

    public List<Personaje> LeerPersonajes(string NombreArchivo){
        using(StreamReader archivo = new StreamReader(NombreArchivo)){
            string JsonString = archivo.ReadToEnd();
            List<Personaje> ListaPersonajes = JsonSerializer.Deserialize<List<Personaje>>(JsonString);
            archivo.Close();
            return ListaPersonajes;
        }
    }

    public bool Existe(string NombreArchivo){
        if(File.Exists(NombreArchivo) && (File.ReadAllText(NombreArchivo)).Length > 0){
            return true;
        }else{
            return false;
        }
    }
}