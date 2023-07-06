namespace PluginRepository.Core.Models;

public partial class UserDisplayModel : ObservableObject
{
    [ObservableProperty]
    [property: BsonId]
    [property: BsonRepresentation(BsonType.ObjectId)]
    private string _id = string.Empty;

    [ObservableProperty]
    private string _displayName;

    public UserDisplayModel(UserModel user)
    {
        _displayName = user.DisplayName;
    }
}
