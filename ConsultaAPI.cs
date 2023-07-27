namespace EspacioPersonaje;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
public class ConsultaAPI{
    public List<string> ObtenerNombres(){
        var url = $"https://fakerapi.it/api/v1/credit_cards?_quantity=10";
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.ContentType = "application/json";
        request.Accept = "application/json";
        Names Nombres = null;
        List<string> ListaNombres = new List<string>();
        try
        {
            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null) return null;
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();
                        Nombres = JsonSerializer.Deserialize<Names>(responseBody);
                    }
                    foreach (var item in Nombres.data)
                    {
                        string nombreCompleto = item.owner;
                        string nombre = nombreCompleto.Split(" ")[0];
                        ListaNombres.Add(nombre);
                    }
                    
                }
            }
        }
        catch (WebException ex)
        {
            Console.WriteLine("Problemas de acceso a la API");
        }
        return ListaNombres;
    }
}

public class Datum
{
    [JsonPropertyName("owner")]
    public string owner { get; set; }
}

public class Names
{
    public List<Datum> data { get; set; }
}