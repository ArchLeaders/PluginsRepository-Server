using System.ComponentModel;

namespace PluginRepository.Core.Models;

public partial class PluginDisplayModel : ObservableObject
{
    [ObservableProperty]
    private string _name;

    public PluginDisplayModel(PluginModel plugin)
    {
        _name = plugin.Name;
    }
}
