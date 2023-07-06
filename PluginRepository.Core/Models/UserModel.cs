namespace PluginRepository.Core.Models;

public partial class UserModel : DataObject
{
    [ObservableProperty]
    private string _objectIdentifier = string.Empty;

    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private string _displayName = string.Empty;

    [ObservableProperty]
    private string _email = string.Empty;

    [ObservableProperty]
    private string? _phone;

    [ObservableProperty]
    private List<PluginDisplayModel> _authoredPlugins = new();

    partial void OnDisplayNameChanged(string? oldValue, string newValue)
    {
        UpdateAuthorReferenced(AuthoredPlugins, newValue);
    }

    /// <summary>
    /// Updates the referenced <see cref="AuthoredPlugins"/> if the <see cref="DisplayName"/> is changed
    /// </summary>
    /// <returns></returns>
    public static void UpdateAuthorReferenced(List<PluginDisplayModel> referenced, string displayName)
    {
        // throw new NotImplementedException();
    }
}
