using PluginRepository.Core.Generics;

namespace PluginRepository.Core.Models;

public enum PluginType
{
    CLI, GUI
}

public enum RequestStatus
{
    /// <summary>
    /// The request has been approved (public)
    /// </summary>
    Approved,

    /// <summary>
    /// The request has been revoked (private)
    /// </summary>
    Revoked,
    
    /// <summary>
    /// The request is in the process of review
    /// </summary>
    Reviewing,

    /// <summary>
    /// The request is pending approval for review
    /// </summary>
    Pending,
}

public partial class PluginModel : DataObject
{
    [ObservableProperty]
    private UserDisplayModel _author;

    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private string _description = string.Empty;

    [ObservableProperty]
    private PluginType _type = PluginType.CLI;

    [ObservableProperty]
    private UserDisplayModel? _reviewer;

    [ObservableProperty]
    private List<CommentModel> _comments = new();

    [ObservableProperty]
    private DateTime _createdAt = DateTime.UtcNow;

    [ObservableProperty]
    private RequestStatus _status = RequestStatus.Pending;

    public PluginModel(UserModel author, string name, string description)
    {
        _author = new(author);
        _name = name;
        _description = description;
    }
}
