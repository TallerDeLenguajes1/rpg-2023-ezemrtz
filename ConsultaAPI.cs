using EspacioPersonaje;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
public class ConsultaAPI{
    public string ObtenerInsulto(){
        var url = $"https://evilinsult.com/generate_insult.php?lang=es&type=json";
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.ContentType = "application/json";
        request.Accept = "application/json";
        Insulto insulto = null;
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
                        insulto = JsonSerializer.Deserialize<Insulto>(responseBody);
                    }
                }
            }
        }
        catch (WebException ex)
        {
            Console.WriteLine("Problemas de acceso a la API");
        }
        return insulto.insult;
    }
}

public class Insulto
    {
        [JsonPropertyName("number")]
        public string number { get; set; }

        [JsonPropertyName("language")]
        public string language { get; set; }

        [JsonPropertyName("insult")]
        public string insult { get; set; }

        [JsonPropertyName("created")]
        public string created { get; set; }

        [JsonPropertyName("shown")]
        public string shown { get; set; }

        [JsonPropertyName("createdby")]
        public string createdby { get; set; }

        [JsonPropertyName("active")]
        public string active { get; set; }

        [JsonPropertyName("comment")]
        public string comment { get; set; }
    }