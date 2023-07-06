namespace PluginRepository.Core.DataAccess;
public interface IDatabaseConnection
{
    MongoClient Client { get; }
    string DbName { get; }

    IMongoCollection<T> GetCollection<T>() where T : DataObject;
}