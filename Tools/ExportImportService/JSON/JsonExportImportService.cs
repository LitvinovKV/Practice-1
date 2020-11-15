using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace Tools.ExportImportService.JSON
{
    public class JsonExportImportService : IExportImportService
    {
        private JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.All
        };

        public async Task Export(object data, string path)
        {
            var indented = Formatting.Indented;
        
            var json = JsonConvert.SerializeObject(data, indented, settings);

            using (var fs = File.Open(path, FileMode.Create))
            using (var sw = new StreamWriter(fs))
            {
                await sw.WriteAsync(json);
            }
        }

        public async Task<T> Import<T>(string path)
        {
            using (var fs = File.Open(path, FileMode.Open))
            using (var sr = new StreamReader(fs))
            {
                var jsonObject = await sr.ReadToEndAsync();
                return JsonConvert.DeserializeObject<T>(jsonObject, settings);
            }
        }
    }
}
