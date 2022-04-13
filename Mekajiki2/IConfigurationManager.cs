using System.Threading.Tasks;

namespace Mekajiki2;

public interface IConfigurationManager
{
    public Configuration Current { get; set; }

    public Task SaveAsync();
}