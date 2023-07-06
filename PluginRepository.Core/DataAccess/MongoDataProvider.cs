using System.Linq.Expressions;

namespace PluginRepository.Core.DataAccess;

public class MongoDataProvider<T> : IDataProvider<T> where T : DataObject
{
    protected readonly IMongoCollection<T> _collection;

    public MongoDataProvider(IDatabaseConnection connection)
    {
        _collection = connection.GetCollection<T>();
    }

    public async Task<List<T>> GetAll()
    {
        var result = await _collection.FindAsync(_ => true);
        return await result.ToListAsync();
    }

    public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter)
    {
        var result = await _collection.FindAsync(filter);
        return await result.ToListAsync();
    }

    public async Task<T> Get(Expression<Func<T, bool>> filter)
    {
        var result = await _collection.FindAsync(filter);
        return await result.FirstOrDefaultAsync();
    }

    public async Task Add(T item)
    {
        await _collection.InsertOneAsync(item);
    }

    public async Task Update(T item)
    {
        var filter = Builders<T>.Filter.Eq("Id", item.Id);
        await _collection.ReplaceOneAsync(filter, item, new ReplaceOptions {
            IsUpsert = true
        });
    }
}
