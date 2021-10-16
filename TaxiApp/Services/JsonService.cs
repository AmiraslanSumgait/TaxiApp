using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TaxiApp.Services
{
    public class JsonService
    {
        public static void WriteToJsonFile<T>(T obj, string path)
        {
            var options = new JsonSerializerOptions(); 
            options.WriteIndented = true;
            options.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            var textJson = JsonSerializer.Serialize(obj, options);
            File.WriteAllText(path, textJson);
        }
    }
}
