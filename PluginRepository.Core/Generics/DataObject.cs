namespace PluginRepository.Core.Generics;

public partial class DataObject : ObservableObject
{
    [ObservableProperty]
    [property: BsonId]
    [property: BsonRepresentation(BsonType.ObjectId)]
    private string _id = string.Empty;
}
