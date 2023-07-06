using Microsoft.Extensions.Configuration;

namespace PluginRepository.Core.DataAccess;

public class DatabaseConnection : IDatabaseConnection
{
    private readonly IMongoDatabase _database;
    private readonly string _connectionId = "MongoDB";

    public string DbName { get; private set; }
    public MongoClient Client { get; private set; }

    public DatabaseConnection(IConfiguration config)
    {
        Client = new(config.GetConnectionString(_connectionId));
        DbName = config["DatabaseName"] ??
            throw new InvalidDataException("Could not find the database name in the configuration");
        _database = Client.GetDatabase(DbName);
    }

    public IMongoCollection<T> GetCollection<T>() where T : DataObject
    {
        return _database.GetCollection<T>($"{typeof(T).Name}Collection");
    }
}
