using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mekajiki2;

public class ConfigurationManager : IConfigurationManager
{
    public Configuration Current { get; set; }

    private string _path;

    public ConfigurationManager(string path = "config.json")
    {
        _path = path;
        if (File.Exists(path))
        {
            Current = FromFile(path);
        }
        else
        {
            Current = new Configuration();
            SaveAsync();
        }
    }

    public async Task SaveAsync()
    {
        await using (Stream fs = File.OpenWrite(_path))
        {
            await JsonSerializer.SerializeAsync(fs, Current);
        }
    }

    public static async Task<Configuration> FromFileAsync(string path)
    {
        await using (Stream fs = File.OpenRead(path))
        {
            return await JsonSerializer.DeserializeAsync<Configuration>(fs);
        }
    }
    
    private static Configuration FromFile(string path)
    {
        using (Stream fs = File.OpenRead(path))
        {
            return JsonSerializer.Deserialize<Configuration>(fs);
        }
    }
}